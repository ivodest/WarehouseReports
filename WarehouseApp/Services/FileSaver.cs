using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlaygroundApp1.Services
{
    public class FileSaver : IFileSaver
    {
        public string PrintToFile(WarehouseReport report)
        {
            var filename = string.Empty;
            try
            {
                filename = string.Format("output-{0}.txt", DateTime.Now.ToString("yyyyMMddHHmmss"));

                using (StreamWriter sw = new StreamWriter(filename))
                {
                    foreach (var warehouse in report.Warehouses)
                    {
                        sw.WriteLine("{0} (total {1})", warehouse.Name, warehouse.Total);
                        foreach (var material in warehouse.Materials)
                        {
                            sw.WriteLine("{0}: {1}", material.Id, material.Amount);
                        }
                        sw.WriteLine();
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be write:");
                Console.WriteLine(e.Message);
            }
            return filename;
        }
    }
}
