using ConsoleApp1.Exceptions;
using ConsoleApp1.Interfaces;

namespace ConsoleApp1.ContainersDirectory;

public class LiquidContainer : ContainerBase, IHazardNotifier
{
    private string CargoType;
    private bool IsHazardous;

    public LiquidContainer(double cargoWeight, double height, double soleWeight, double depth, double maxPayload) :
        base(cargoWeight, height, soleWeight, depth, maxPayload)
    {
        CargoType = "";
        IsHazardous = false;
    }

    public override void ReloadingContainers(double cargo)
    {
        try
        {
            if (cargo + CargoWeight > MaxPayload)
            {
                throw new OverfillException("Adding this cargo will exceed the container maximum payload!");
            }

            CargoWeight += cargo;
            Console.WriteLine("Added a load weighing " + cargo + " kg to container No. " + SerialNumber);
        }
        catch (OverfillException e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
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