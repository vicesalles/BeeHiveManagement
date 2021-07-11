using System;
using System.Collections.Generic;
using System.Text;

namespace BeeHiveManagement
{
    static class HoneyVault
    {
        const float NECTAR_CONVERSION_RATIO = .19f;
        const float LOW_LEVEL_WARNING = 10f;
        private static float honey = 25f;
        private static float nectar = 100f;

        public static string StatusReport
        {
            get
            {
                string status = "";
                if (honey <= LOW_LEVEL_WARNING)
                {
                    status += $"LOW HONEY - ADD A HONEY MANUFACTURER {Environment.NewLine}";
                }
                if (nectar <= LOW_LEVEL_WARNING)
                {
                    status += "LOW NECTAR - ADD A NECTAR COLLECTOR";
                }

                return status;
            }
        }

        public static void ConvertNectarToHonet(float amount)
        {
            float finalAmount;
            float difference = nectar - amount;
            
            if(difference < 0)
            {
                finalAmount = amount + difference;
            }
            else
            {
                finalAmount = amount;
            }

            nectar -= finalAmount;
            honey += finalAmount * NECTAR_CONVERSION_RATIO;     

        }

        public static bool ConsumeHoney(float amount)
        {
            if (honey > amount)
            {
                honey -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void CollectNectar(float amount)
        {
            nectar += amount;
        }

    }
}
