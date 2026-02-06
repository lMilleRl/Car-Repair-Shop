namespace CarService;

public class Client
{
    public BrokenCar OwnCar { get; set; }

    public Client(BrokenCar ownCar)
    {
        OwnCar = ownCar;
    }
}