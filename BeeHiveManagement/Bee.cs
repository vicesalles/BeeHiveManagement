using System;
using System.Collections.Generic;
using System.Text;

namespace BeeHiveManagement
{
    class Bee
    {
        public string Job {get;}
        public virtual float CostPerShift { get; }
        
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
        
        protected virtual void DoJob()
        {

        }

        
    }
}
