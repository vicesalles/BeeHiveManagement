using System;
using System.Collections.Generic;
using System.Text;

namespace BeeHiveManagement
{
    class NectarCollector : Bee
    {
        public override float CostPerShift { get => 1.95f; }
        const float NECTAR_COLLECTER_PER_SHIFT = 33.25f;

        public NectarCollector() : base("Nectar Collector")
        {

        }

        protected override void DoJob()
        {
            HoneyVault.CollectNectar(NECTAR_COLLECTER_PER_SHIFT);
        }
    }
}
