using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlaygroundApp1.Services
{
    public class WarehouseManager : IWarehouseManager
    {
        public void UpdateWarehouse(WarehouseReport report, Material material, string whName)
        {
            foreach (var wh in report.Warehouses.Where(x => x.Name == whName))
            {
                if (wh.Materials.Any(m => m.Id.Equals(material.Id)))
                {
                    wh.Materials.Where(m => m.Id.Equals(material.Id)).FirstOrDefault().Amount += material.Amount;
                }
                else
                {
                    wh.Materials.Add(material);
                }
            }
        }

        public Warehouse CreateWarehouse(Material material, string[] warehouseInfo)
        {
            var newWarehouse = new Warehouse();
            newWarehouse.Materials = new List<Material>();
            newWarehouse.Name = warehouseInfo[0];
            newWarehouse.Materials.Add(material);

            return newWarehouse;
        }
    }
}
