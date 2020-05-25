using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlaygroundApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter filename (*.txt) or press ENTER for exampleInput.txt");
            string filename = Console.ReadLine();

            if(string.IsNullOrEmpty(filename))
            {
                filename = "exampleInput.txt";
            }
            var reportService = new ReportService();
            var reportName = reportService.GenerateReport(filename);

            Console.WriteLine("Report has been printed out to: {0}", reportName);
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }
    }
}
