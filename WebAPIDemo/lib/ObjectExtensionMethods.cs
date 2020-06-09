﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace WebAPIDemo.lib
{
    public static class ObjectExtensionMethods
    {

        public static void CopyPropertiesFrom(this object self, object parent)
        {
            var fromProperties = parent.GetType().GetProperties();
            var toProperties = self.GetType().GetProperties();
            foreach (var fromProperty in fromProperties)
            {
                foreach (var toProperty in toProperties)
                {
                    if (fromProperty.Name == toProperty.Name && fromProperty.Name.Equals("ID"))
                        break;
                    if (fromProperty.Name == toProperty.Name && fromProperty.PropertyType == toProperty.PropertyType)
                    {
                        toProperty.SetValue(self, fromProperty.GetValue(parent));
                        break;
                    }
                }
            }
        }
    }
}