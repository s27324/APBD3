using ConsoleApp1.Exceptions;
using ConsoleApp1.Interfaces;

namespace ConsoleApp1.ContainersDirectory.LiquidContainers;

public class LiquidContainer : ContainerBase, IHazardNotifier
{
    public LiquidContainer(double cargoWeight, double height, double soleWeight, double depth, double maxPayload) : base(cargoWeight, height, soleWeight, depth, maxPayload)
    {}

    public override void ReloadingContainers(double Cargo)
    {
        if (Cargo + CargoWeight > MaxPayload)
        {
            throw new OverfillException("Adding this cargo will exceed the container maximum payload!");
        }
        else
        {
            CargoWeight += Cargo;
            Console.WriteLine("Added a load weighing" + Cargo + " kg to container No. " + SerialNumber);
        }
    }

    public void NotifyDanger()
    {
        Console.WriteLine("Dangerous situation! Container No. " + SerialNumber);
    }
}