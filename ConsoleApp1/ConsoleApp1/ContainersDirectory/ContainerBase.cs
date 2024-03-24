namespace ConsoleApp1.ContainersDirectory;

public abstract class ContainerBase
{
    protected internal double CargoWeight { get; set; }
    protected double Height { get; set; }
    protected internal double SoleWeight { get; set; }
    protected double Depth { get; set; }
    private static int number = 0;
    protected internal string SerialNumber { get; }
    protected double MaxPayload { get; set; }

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

    public override string ToString()
    {
        return SerialNumber + ", cargo weight: " + CargoWeight + ", height: " + Height + ", sole weight: " + SoleWeight +
               ", depth: " + Depth + ", maximum payload: " + MaxPayload;
    }
}