namespace CarService;

class Program
{
    private const int COUNT_CARS_TO_SERVE = 10;
    private const double WORK_ALLOWANCE_FACTOR = 1.2;
    
    static void Main(string[] args)
    {
        var carservice = new AutoRepairShop(WarehouseFormer.GetBaseInitWarehouse(), WORK_ALLOWANCE_FACTOR);
        var workDay = new WorkDay();
        workDay.Work(COUNT_CARS_TO_SERVE, carservice, false);
    }
}