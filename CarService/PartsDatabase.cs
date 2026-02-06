namespace CarService;

internal static class PartsDatabase
{
    private static readonly List<PartsGroup> _initPartsGroups = new()
    {
        new PartsGroup(new Part("Wheel", 200), 10),
        new PartsGroup(new Part("Tire", 50), 10),
        new PartsGroup(new Part("Car door", 150), 10),
        new PartsGroup(new Part("Engine", 500), 5),
        new PartsGroup(new Part("Battery", 100), 7),
        new PartsGroup(new Part("Filter", 40), 10),
    };
    
    public static IReadOnlyList<PartsGroup> InitPartsGroups => _initPartsGroups.AsReadOnly();
}