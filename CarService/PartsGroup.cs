using Common.Validation;

namespace CarService;

public class PartsGroup
{
    private int _count;
    
    private readonly Part _partInstance;

    public Part PartInstance => _partInstance;

    public int Count
    {
        get => _count;
        private set
        {
            Validator.ThrowIfNegativeNumber(value, nameof(value));
            _count = value;
        }
    }

    public PartsGroup(Part partInstance, int count = 0)
    {
        _partInstance = partInstance;
        Count = count;
    }

    public void AddOnePart() => Count++;

    public bool TryTakePart(out Part part)
    {
        if (Count == 0)
        {
            part = null;
            return false;
        }

        part = PartInstance.Clone();
        Count--;
        return true;
    }
}