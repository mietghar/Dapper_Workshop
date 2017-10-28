using System;
using System.Collections;
using System.Collections.Generic;

namespace Common.Utility
{
    public static class ConsoleExtension
    {
        public static void WriteObject(object objectToWrite)
        {
            if (objectToWrite == null) return;
            if(objectToWrite is IList && objectToWrite.GetType().IsGenericType && objectToWrite.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>)))
            {
                WriteObjectList(objectToWrite as IEnumerable<object>);
                return;
            }
            WriteObjectPropertiesInConsole(objectToWrite);
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
