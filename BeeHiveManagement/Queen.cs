using System;


namespace BeeHiveManagement
{

    using System.ComponentModel;

    class Queen : Bee, INotifyPropertyChanged
    {

        const float EGGS_PER_SHIFT = 0.45f;
        const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;

        private Bee[] workers = new Bee[0];

        private float eggs = 0;
        private float unassignedWorkers = 3;

        public event PropertyChangedEventHandler PropertyChanged;

        public override float CostPerShift { get => 2.15f; }
        public string StatusReport { get; private set; }

        public Queen() : base("Queen") {

            AssignBee("Egg Care");
            AssignBee("Honey Manufacturer");
            AssignBee("Nectar Collector");           

        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected override void DoJob()
        {
            eggs += EGGS_PER_SHIFT;
            
            foreach(Bee bee in workers)
            {
               bee.WorkTheNextShift();
            }
            
            HoneyVault.ConsumeHoney(unassignedWorkers * HONEY_PER_UNASSIGNED_WORKER);
            UpdateStatusReport();
        }

        public void AddWorker(Bee bee)
        {
            if(unassignedWorkers >= 1)
            {
                unassignedWorkers--;
                Array.Resize(ref workers, workers.Length + 1);
                workers[workers.Length-1] = bee;
                UpdateStatusReport();
            }
            
        }

        public void AssignBee(string job)
        {            
            switch (job)
            {
                case "Egg Care":
                    AddWorker(new EggCare(this));                    
                    break;
                case "Honey Manufacturer":
                    AddWorker(new HoneyManufacturer());                    
                    break;
                case "Nectar Collector":
                    AddWorker(new NectarCollector());                    
                    break;
            }
            
        }

        public void UpdateStatusReport()
        {
            StatusReport = $"Vault report:\n{HoneyVault.StatusReport}\n"+
                $"Egg count:{eggs:0.0}\n \nUnassigned wokers: {unassignedWorkers:0.0}\n" +
                $"\n{WorkerStatus("Nectar Collector")}\n{WorkerStatus("Honey Manufacturer")}\n" +
                $"{ WorkerStatus("Egg Care")}\n \nTOTAL WORKERS: {workers.Length}\n";
            OnPropertyChanged("StatusReport");
        }

        private string WorkerStatus(string job)
        {
            int count = 0;
            foreach (Bee worker in workers)
            {
                if (worker.Job == job) count++;
            }
            string s = "s";
            if (count == 1) s = "";
            return $"{count} {job} bee{s}";
        }

        public void CareForEggs(float eggsToConvert)
        {
            if(eggs >= eggsToConvert)
            {
                eggs -= eggsToConvert;
                unassignedWorkers += eggsToConvert;
            }
        }

    }
}
