using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlaygroundApp1.Services
{
    public class FileLoader : ILoader
    {
        Deserializer deserializer;
        public FileLoader()
        {
            deserializer = new Deserializer();
        }

        public void Load(string fileName, WarehouseReport report)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (!line.StartsWith("#"))
                        {
                            deserializer.DeserializeLine(line, report);
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
    }
}
