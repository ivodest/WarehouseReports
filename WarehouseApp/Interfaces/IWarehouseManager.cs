namespace ConsolePlaygroundApp1.Services
{
    public interface IWarehouseManager
    {
        void UpdateWarehouse(WarehouseReport report, Material material, string warehouseName);
        Warehouse CreateWarehouse(Material material, string[] warehouseInfo);
    }
}