using ConsoleApp1.Interfaces;

namespace ConsoleApp1.ContainersDirectory.LiquidContainers;

public class LiquidContainer : ContainerBase, IHazardNotifier
{
    public LiquidContainer(double cargoWeight, double height, double soleWeight, double depth, double maxPayload) : base(cargoWeight, height, soleWeight, depth, maxPayload)
    {}

    public override void ReloadingContainers(double Cargo)
    {
        if (Cargo > MaxPayload)
        {
            //todo
            throw new NotImplementedException();
        }
    }

    public void NotifyDanger()
    {
        Console.WriteLine("Dangerous situation! Container No. " + SerialNumber);
    }
}