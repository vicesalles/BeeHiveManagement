using System;
using System.Collections.Generic;
using System.Text;

namespace BeeHiveManagement
{
    abstract class Bee
    {
        public string Job {get;}
        public abstract float CostPerShift { get; }
        
        public Bee (string job)
        {
            Job = job;
        }

        public void WorkTheNextShift()
        {
            if (HoneyVault.ConsumeHoney(CostPerShift))
            {
                DoJob();
            }
        }

        protected abstract void DoJob();

        
    }
}
