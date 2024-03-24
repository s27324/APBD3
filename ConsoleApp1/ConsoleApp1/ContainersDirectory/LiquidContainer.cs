using ConsoleApp1.Exceptions;
using ConsoleApp1.Interfaces;

namespace ConsoleApp1.ContainersDirectory;

public class LiquidContainer : ContainerBase, IHazardNotifier
{
    private bool IsHazardous { get; set; }

    public LiquidContainer(double cargoWeight, double height, double soleWeight, double depth, double maxPayload, bool isHazardous) :
        base(cargoWeight, height, soleWeight, depth, maxPayload)
    {
        IsHazardous = isHazardous;
    }

    public override void ReloadingContainers(double cargo)
    {
        try
        {
            if (IsHazardous && cargo + CargoWeight > MaxPayload * 0.5)
            {
                NotifyDanger();
                throw new OverfillException("Adding this hazardous cargo will exceed the container maximum payload!");
            } 
            else if (!IsHazardous && cargo + CargoWeight > MaxPayload * 0.9)
            {
                NotifyDanger();
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
        CargoWeight = 0;
        Console.WriteLine("Container No. " + SerialNumber + " was emptied.");
    }

    public void NotifyDanger()
    {
        Console.WriteLine("Dangerous situation! Container No. " + SerialNumber);
    }

    public override string ToString()
    {
        return "Liquid container: " + base.ToString() + ", hazardous: " + IsHazardous;
    }
}