namespace CarService;

public class Warehouse
{
    private readonly List<PartsGroup> _partsGroup;

    public IReadOnlyList<PartsGroup> PartsGroups => _partsGroup.AsReadOnly();

    public Warehouse() => _partsGroup = new List<PartsGroup>();

    public Warehouse(List<PartsGroup> initPartsGroups)
    {
        _partsGroup = new List<PartsGroup>(initPartsGroups);
    }

    public bool TryTakePart(int index, out Part part)
    {
        if (index < 0 || index >= _partsGroup.Count)
        {
            part = null;
            return false;
        }

        _partsGroup[index].TryTakePart(out part);
        return true;
    }

    public bool TryAddPart(int index)
    {
        if (index < 0 || index >= _partsGroup.Count)
            return false;

        _partsGroup[index].AddOnePart();
        return true;
    }
}