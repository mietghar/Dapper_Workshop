using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Common.Utility
{
    public static class ConsoleExtension
    {
        public static void WriteObject(object objectToWrite)
        {
            if (objectToWrite == null)
            {
                Console.WriteLine($"Object is of type null");
                return;
            }
            if(objectToWrite is IList && objectToWrite.GetType().IsGenericType && objectToWrite.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>)))
            {
                WriteObjectList(objectToWrite as IEnumerable<object>);
                return;
            }

            WriteObjectPropertiesInConsole(objectToWrite);
        }

        public static void WriteDynamicObject(object objectToWrite)
        {
            if (objectToWrite == null)
            {
                Console.WriteLine($"Object is of type null");
                return;
            }
            if (objectToWrite.GetType().GetInterfaces().Contains(typeof(IDynamicMetaObjectProvider)))
                WriteDynamicObjectPropertiesInConsole(objectToWrite);
            else Console.WriteLine("Object is not dynamic");
        }

        private static void WriteDynamicObjectPropertiesInConsole(dynamic objectToWrite)
        {
            try
            {
                var employee = new
                {
                    objectToWrite.FirstName,
                    objectToWrite.LastName,
                    objectToWrite.EmployeeId,
                    objectToWrite.AddressId
                };
                if (employee != null) WriteObjectPropertiesInConsole(employee);
            }
            catch(RuntimeBinderException exception)
            {
                Console.WriteLine($"Exception thrown\n{exception.Message}");
            }
        }

        private static void WriteObjectList(IEnumerable<object> objectToWrite)
        {
            int i = 1;
            foreach(var element in objectToWrite)
            {
                Console.WriteLine($"\nElement nr {i}: \n");
                WriteObjectPropertiesInConsole(element);
                i++;
            }
        }

        private static void WriteObjectPropertiesInConsole(object objectToWrite)
        {
            var _properties = objectToWrite.GetType().GetProperties();
            var type = objectToWrite.GetType();
            foreach (var _property in _properties)
            {
                Console.WriteLine($"{_property.Name}: {_property.GetValue(objectToWrite).ToString()}");
            }
        }
    }
}
