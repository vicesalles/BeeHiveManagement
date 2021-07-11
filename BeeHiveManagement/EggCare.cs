using System;
using System.Collections.Generic;
using System.Text;

namespace BeeHiveManagement
{
    class EggCare : Bee
    {
        public override float CostPerShift { get => 1.35f; }
        const float CARE_PROGRESS_PER_SHIFT = 0.15f;
        private Queen queen;

        public EggCare(Queen queen) : base("Egg Care") {

            this.queen = queen;
        
        }

        protected override void DoJob()
        {
            queen.CareForEggs(CARE_PROGRESS_PER_SHIFT);
        }
    }
}
