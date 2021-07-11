using System;
using System.Collections.Generic;
using System.Text;

namespace BeeHiveManagement
{
    class HoneyManufacturer: Bee
    {
        public override float CostPerShift { get => 1.7f; }
        const float NECTAR_PROCESSED_PER_SHIFT = 33.15f;

        public HoneyManufacturer() : base("Honey Manufacturer"){}

        protected override void DoJob()
        {
            HoneyVault.ConvertNectarToHonet(NECTAR_PROCESSED_PER_SHIFT);
        }
    }
}
