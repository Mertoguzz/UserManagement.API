using ETS.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserManagementAPI.Helpers
{
    public class UserHelpers
    {
        public bool CheckMandatoryProperties(object objct, ref string messages)
        {
            List<MyKeyValuePair> properties = Helper.GetStringPropertiesByObject(objct);
            StringBuilder msg = new StringBuilder();
            if (properties.Any())
            {
                foreach (MyKeyValuePair item in properties)
                {
                    if (item.Name == "Address")
                    {
                        continue;
                    }
                    if (Helper.IsEmptyString(Convert.ToString(item.Value)) )
                    {
                        msg.Append($"{item.Name} cannot be empty. ");
                    }
                }
            }
            if (msg.Length>0)
            {
                messages = msg.ToString();
                return false;
            }
            return true;
        }

      

        internal string CreateRandomTCKN()
        {
            Random rnd = new Random();
            int value = rnd.Next(100_000_000, 1_000_000_000);
            return GenerateIdFromValue(value);
        }

        private static string GenerateIdFromValue(int x)
        {
            int d1 = x / 100_000_000;
            int d2 = (x / 10_000_000) % 10;
            int d3 = (x / 1_000_000) % 10;
            int d4 = (x / 100_000) % 10;
            int d5 = (x / 10_000) % 10;
            int d6 = (x / 1000) % 10;
            int d7 = (x / 100) % 10;
            int d8 = (x / 10) % 10;
            int d9 = x % 10;
            int oddSum = d1 + d3 + d5 + d7 + d9;
            int evenSum = d2 + d4 + d6 + d8;
            int firstChecksum = ((oddSum * 7) - evenSum) % 10;
            if (firstChecksum < 0)
            {
                firstChecksum += 10;
            }
            int secondChecksum = (oddSum + evenSum + firstChecksum) % 10;
            return String.Format("{0}{1}{2}", x, firstChecksum, secondChecksum);
        }
    }
}
