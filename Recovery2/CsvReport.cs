using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;

namespace Recovery2
{
    public static class CsvReport
    {
        public static void WriteCsv<T>(IEnumerable<T> items, string path = "Report.csv")
        {
            if (File.Exists(path))
            {
                using (var stream = File.Open(path, FileMode.Append))
                using (var writer = new StreamWriter(stream, new UTF8Encoding(true)))
                using (var csv = new CsvWriter(writer))
                {
                    csv.Configuration.CultureInfo = CultureInfo.InvariantCulture;
                    csv.Configuration.HasHeaderRecord = false;
                    csv.Configuration.Delimiter = ";";
                    var lst = items.ToList();
                    if (lst.Count > 0)
                    {
                        csv.WriteRecords(lst);
                    }
                }

                return;
            }

            using (var writer = new StreamWriter(path, true, new UTF8Encoding(true)))
            using (var csv = new CsvWriter(writer))
            {
                csv.Configuration.CultureInfo = CultureInfo.InvariantCulture;
                csv.Configuration.Delimiter = ";";
                csv.WriteRecords(items);
            }
        }
    }
}