using Common.Validation;

namespace CarService;

public class Part
{
    private double _cost;
    
    public string Name { get; private set; }
    
    public bool IsBroken { get; private set; }

    public double Cost
    {
        get => _cost;
        private set
        {
            Validator.ThrowIfNegativeNumber(value, nameof(Cost));
            _cost = value;
        }
    }
    
    public Part(string name, double cost, bool isBroken = false)
    {
        Name = name;
        Cost = cost;
        IsBroken = isBroken;
    }
    
    public void Break() => IsBroken = true;
    
    public Part Clone() => new Part(Name, Cost, IsBroken);
}