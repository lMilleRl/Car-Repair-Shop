namespace CarService;

public class ClientsFormer
{
    private BrokenCarsFormer _brokenCarsFormer;

    public ClientsFormer(BrokenCarsFormer brokenCarsFormer)
    {
        _brokenCarsFormer = brokenCarsFormer;
    }

    public Client GetRandomClient()
    {
        return new Client(_brokenCarsFormer.GetRandomBrokenCar());
    }
}