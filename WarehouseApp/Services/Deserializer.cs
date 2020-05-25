using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlaygroundApp1.Services
{
    public class Deserializer
    {
        IWarehouseManager warehouseManager;

        public Deserializer()
        {
            warehouseManager = new WarehouseManager();
        }

        public void DeserializeLine(string inputLine, WarehouseReport report)
        {
            var splittedItems = inputLine.Split(';');

            var material = new Material();
            material.Name = splittedItems[0].Trim();
            material.Id = splittedItems[1];

            var warehouses = splittedItems[2].Split('|');

            foreach (var wh in warehouses)
            {
                var whInfo = wh.Split(',');
                var whName = whInfo[0];
                material.Amount = int.Parse(whInfo[1]);

                if (report.Warehouses.Any(x => x.Name == whName))
                {
                    warehouseManager.UpdateWarehouse(report, material, whName);
                }
                else
                {
                    var warehouse = warehouseManager.CreateWarehouse(material, whInfo);
                    report.Warehouses.Add(warehouse);
                }
            }
        }
    }
}
