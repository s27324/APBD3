namespace ConsoleApp1.ContainersDirectory;

public class ContainerBase
{
    protected double CargoWeight;
    protected double Height;
    protected double SoleWeight;
    protected double Depth;
    private static int number = 0;
    protected string SerialNumber;
    protected double MaxPayload;

    public ContainerBase(double cargoWeight, double height, double soleWeight, double depth, string serialNumber, double maxPayload)
    {
        CargoWeight = cargoWeight;
        Height = height;
        SoleWeight = soleWeight;
        Depth = depth;
        SerialNumber = serialNumber;
        MaxPayload = maxPayload;
    }
}