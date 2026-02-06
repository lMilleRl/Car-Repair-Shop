namespace CarService;

public class BrokenCar
{
    public Part BrokenPart { get; private set; }

    public BrokenCar(Part brokenPart)
    {
        BrokenPart = brokenPart;
    }

    public bool TryReplaceBrokenPart(Part replacementPart)
    {
        if (replacementPart.Name != BrokenPart.Name)
            return false;
        
        BrokenPart = replacementPart;
        return true;
    }
}