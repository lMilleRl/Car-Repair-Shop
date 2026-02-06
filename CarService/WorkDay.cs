using Common.Input;
using Common.Output;

namespace CarService;

public class WorkDay
{
    private AutoRepairShop _autoRepairShopToWork;
    private ClientsFormer _randomClientsFormer;

    public WorkDay()
    {
        _randomClientsFormer = new ClientsFormer(new BrokenCarsFormer());
    }

    public void Work(int countCarsToServe, AutoRepairShop autoRepairShopToWork, bool isEndlessShift = false)
    {
        _autoRepairShopToWork = autoRepairShopToWork;
        var currentWarehouse = autoRepairShopToWork.PartWarehouse;

        while (countCarsToServe > 0 || isEndlessShift)
        {
            var client = _randomClientsFormer.GetRandomClient();
            var carToRepair = client.OwnCar;

            UIWriter.WriteAboutNewClient(client);

            UIWriter.WriteCarServiceStatus(autoRepairShopToWork);
            UIWriter.WritePartsGroups(autoRepairShopToWork.PartWarehouse);
            UIWriter.WriteRequestToInputPart();
            
            PerformRepair(carToRepair);

            countCarsToServe--;
            GeneralUIWriter.RequestPressButtonToContinue();
            Console.ReadKey();
            Console.Clear();
        }

        void PerformRepair(BrokenCar carToRepair)
        {
            ConsoleReader.ReadIntInRange(out int partNumber, 1, currentWarehouse.PartsGroups.Count);
            var partIndex = partNumber - 1;

            if (TryGetPartAt(partIndex, out Part part))
            {
                if (TryToRepair(carToRepair, part))
                    GetMoney(part);
                else
                    ClaimDamages(part);
            }
            else
                PayFine(carToRepair.BrokenPart);
        }
        
        void PayFine(Part partToReplace)
        {
            _autoRepairShopToWork.TakeMoney(partToReplace.Cost * _autoRepairShopToWork.WorkAllowanceFactor);
        }

        void ClaimDamages(Part partToCompensated)
        {
            _autoRepairShopToWork.TakeMoney(partToCompensated.Cost);
        }

        void GetMoney(Part replacementPart)
        {
            _autoRepairShopToWork.AddMoney(replacementPart.Cost * _autoRepairShopToWork.WorkAllowanceFactor);
        }

        bool TryToRepair(BrokenCar carToRepair, Part partToReplace)
        {
            return carToRepair.TryReplaceBrokenPart(partToReplace);
        }

        bool TryGetPartAt(int index, out Part part)
        {
            if (!_autoRepairShopToWork.TryTakeFromWarehouse(index, out part))
                return false;

            return true;
        }
    }
}