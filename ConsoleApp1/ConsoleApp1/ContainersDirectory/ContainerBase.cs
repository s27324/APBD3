namespace ConsoleApp1.ContainersDirectory;

public abstract class ContainerBase
{
    protected double CargoWeight;
    protected double Height;
    protected double SoleWeight;
    protected double Depth;
    private static int number = 0;
    protected string SerialNumber { get; }
    protected double MaxPayload;

    public ContainerBase(double cargoWeight, double height, double soleWeight, double depth, double maxPayload)
    {
        CargoWeight = cargoWeight;
        Height = height;
        SoleWeight = soleWeight;
        Depth = depth;
        number++;
        SerialNumber = "KON-" + GetType().Name[0] + "-" + number;
        MaxPayload = maxPayload;
    }

    public abstract void ReloadingContainers(double Cargo);

    public abstract void EmptyingContainer();
}