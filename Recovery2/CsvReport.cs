using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
                using (var writer = new StreamWriter(stream))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.Configuration.HasHeaderRecord = false;
                    csv.Configuration.Delimiter = ";";
                    csv.WriteRecords(items);
                }

                return;
            }

            using (var writer = new StreamWriter(path))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = ";";
                csv.WriteRecords(items);
            }
        }
    }
}