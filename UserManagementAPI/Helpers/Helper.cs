using ETS.UI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace UserManagementAPI.Helpers
{
    public class Helper
    {
        public static bool IsEmptyString(string value)
        {
            return (NormalizeString(value) == string.Empty);
        }

        public static string NormalizeString(string value)
        {
            if (value == null)
                value = string.Empty;
            return value.Trim();
        }

        public static List<MyKeyValuePair> GetStringPropertiesByObject(object myObject)
        {
            List<MyKeyValuePair> stringPropertyNamesAndValues = (List<MyKeyValuePair>)myObject.GetType()
                         .GetProperties()
                         .Where(pi => pi.PropertyType == typeof(string) && pi.GetGetMethod() != null)
                         .Select(pi => new MyKeyValuePair
                         {
                             Name = pi.Name,
                             Value = pi.GetGetMethod().Invoke(myObject, null)
                         }).ToList();


            return stringPropertyNamesAndValues;
        }

        public static bool IsNumeric(string value)
        {
            Regex objNotNumberPattern = new Regex("/^[0-9]*$/");
            long num = 0;
            long.TryParse(value, out num);

            return objNotNumberPattern.IsMatch(value) || num > 0;
        }
    }
}
