namespace CarService;

internal static class UIWriter
{
    public static void WritePartsGroups(Warehouse partsWarehouse)
    {
        Console.WriteLine($"List of parts' of groups in the warehouse:");
        var partsGroups = partsWarehouse.PartsGroups;
        for (int i = 0; i < partsGroups.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Name of part's type: {partsGroups[i].PartInstance.Name}" +
                              $", cost: {partsGroups[i].PartInstance.Cost}, count: {partsGroups[i].Count}");
        }
    }

    public static void WriteCarServiceStatus(AutoRepairShop carService)
    {
        Console.WriteLine("===AUTO REPAIR SHOP STATUS===");
        Console.WriteLine($"Current cash: {carService.Cash}");
    }
    
    public static void WriteAboutNewClient(Client carServiceClient)
    {
        Console.WriteLine($"Client's car has: {carServiceClient.OwnCar.BrokenPart.Name}" +
                          $", is broken: {carServiceClient.OwnCar.BrokenPart.IsBroken}");
    }

    public static void WriteRequestToInputPart()
    {
        Console.WriteLine($"Enter a number of part to replace the broken one:");
    }
}