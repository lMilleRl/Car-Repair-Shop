namespace CarService;

internal static class WarehouseFormer
{
    public static Warehouse GetBaseInitWarehouse()
    {
        return new Warehouse(new List<PartsGroup>(PartsDatabase.InitPartsGroups));
    }
}