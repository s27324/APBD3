using ConsoleApp1.Interfaces;

namespace ConsoleApp1.ContainersDirectory;

public class GasContainer : ContainerBase, IHazardNotifier
{
    public GasContainer(double cargoWeight, double height, double soleWeight, double depth, double maxPayload) : base(cargoWeight, height, soleWeight, depth, maxPayload)
    {
    }

    public override void ReloadingContainers(double Cargo)
    {
        throw new NotImplementedException();
    }

    public override void EmptyingContainer()
    {
        throw new NotImplementedException();
    }

    public void NotifyDanger()
    {
        Console.WriteLine("Dangerous situation! Container No. " + SerialNumber);
    }
}