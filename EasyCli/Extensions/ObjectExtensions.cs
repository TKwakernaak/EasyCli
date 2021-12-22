using System;
using System.Linq;

namespace EasyCli.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Write all property names and values to the console.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        public static void WriteToConsole<T>(this T command)
        {
            var properties = command.GetType()
                                    .GetProperties()
                                    .Where(p => !p.PropertyType.IsClass || p.PropertyType == typeof(string));

            Console.WriteLine($"Command: {command.GetType()}");

            foreach (var prop in properties)
            {
                Console.WriteLine($"{prop.Name} : {prop.GetValue(command)}");
            }
        }
    }
}
