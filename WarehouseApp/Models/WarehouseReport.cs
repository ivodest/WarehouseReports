using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePlaygroundApp1
{
    public class WarehouseReport
    {
        public WarehouseReport()
        {
            Warehouses = new List<Warehouse>();
        }

        public List<Warehouse> Warehouses { get; set; }
    }
}
