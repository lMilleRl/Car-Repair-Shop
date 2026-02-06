using Common.Validation;

namespace CarService;

public class AutoRepairShop
{
    private double _workAllowanceFactor;
    private readonly Warehouse _partWarehouse;

    public Warehouse PartWarehouse => _partWarehouse;

    public double Cash { get; private set; }

    public double WorkAllowanceFactor
    {
        get => _workAllowanceFactor;
        private set
        {
            Validator.ThrowIfNegativeNumber(value, nameof(value));
            _workAllowanceFactor = value;
        }
    }

    public AutoRepairShop(Warehouse ownPartWarehouse, double workAllowanceFactor, double initCash = 0)
    {
        _partWarehouse = ownPartWarehouse;
        WorkAllowanceFactor = workAllowanceFactor;
        Cash = initCash;
    }

    public bool TryAddPartInWarehouse(int index) => _partWarehouse.TryAddPart(index);

    public bool TryTakeFromWarehouse(int index, out Part part) => _partWarehouse.TryTakePart(index, out part);
    
    public void AddMoney(double cash)
    {
        Validator.ThrowIfNegativeNumber(cash, nameof(cash));
        Cash += cash;
    }

    public double TakeMoney(double countToTake)
    {
        Cash -= countToTake;
        return countToTake;
    }
}