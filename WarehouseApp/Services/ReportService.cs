using ConsolePlaygroundApp1.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlaygroundApp1
{
    public class ReportService
    {
        ILoader loader;
        IFileSaver fileSaver;
        
        WarehouseReport report;

        public ReportService()
        {
            loader = new FileLoader();
            fileSaver = new FileSaver();
        }

        public string GenerateReport(string fileName)
        {
            report = new WarehouseReport();

            loader.Load(fileName, report);
            SortReport(report);
            CountMaterialsTotal(report);
            var reportName = fileSaver.PrintToFile(report);

            return reportName;
        }

        private void CountMaterialsTotal(WarehouseReport report)
        {
            foreach (var wh in report.Warehouses)
            {
                wh.Total = wh.Materials.Sum(x => x.Amount);
            }
        }

        private void SortReport(WarehouseReport report)
        {
            report.Warehouses.OrderBy(x => x.Materials.Sum(y => y.Amount));

            foreach (var wh in report.Warehouses)
            {
                wh.Materials = wh.Materials.OrderBy(x => x.Id).ToList();
            }
        }
    }
}
