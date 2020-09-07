using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Recovery2
{
    public static class CsvReport
    {
        public static void WriteCsv<T>(IEnumerable<T> items, string path = "Report.csv")
        {
            var itemType = typeof(T);
            var props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .OrderBy(p => p.Name);

            
            using (var writer = new StreamWriter(path))
            {
                writer.WriteLine(string.Join(";", props.Select(p => p.Name)));

                foreach (var item in items)
                {
                    writer.WriteLine(string.Join(";", props.Select(p => p.GetValue(item, null))));
                }
            }
        }
    }
}