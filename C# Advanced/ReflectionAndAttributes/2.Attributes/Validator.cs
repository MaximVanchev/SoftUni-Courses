using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] propertyInfo = obj.GetType().GetProperties();
            foreach (var property in propertyInfo)
            {
                MyValidationAttribute[] attributes = property.GetCustomAttributes().Cast<MyValidationAttribute>().ToArray();
                foreach (var attribute in attributes)
                {
                    if (attribute.IsValid(property.GetValue(obj)) == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
