namespace CarService;

public class BrokenCarsFormer
{
    private static Random _carsRandomizer;
    
    static BrokenCarsFormer() => _carsRandomizer = new Random();
        
    public BrokenCar GetRandomBrokenCar()
    {
        var randomIndex = _carsRandomizer.Next(0, PartsDatabase.InitPartsGroups.Count);
        var randomBrokenPart = PartsDatabase.InitPartsGroups[randomIndex].PartInstance.Clone();
        randomBrokenPart.Break();
        return new BrokenCar(randomBrokenPart);
    }
}