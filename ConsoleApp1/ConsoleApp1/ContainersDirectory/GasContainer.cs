using ConsoleApp1.Exceptions;
using ConsoleApp1.Interfaces;

namespace ConsoleApp1.ContainersDirectory;

public class GasContainer : ContainerBase, IHazardNotifier
{
    private double CargoPressure { get; set; }
    public GasContainer(double cargoWeight, double height, double soleWeight, double depth, double maxPayload, double cargoPressure) : base(cargoWeight, height, soleWeight, depth, maxPayload)
    { 
        CargoPressure = cargoPressure;
    }

    public override void ReloadingContainers(double cargo)
    {
        try
        {
            if (cargo + CargoWeight > MaxPayload)
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
        CargoWeight *= 0.05;
        Console.WriteLine("Container No. " + SerialNumber + " was emptied.");
    }

    public void NotifyDanger()
    {
        Console.WriteLine("Dangerous situation! Container No. " + SerialNumber);
    }

    public override string ToString()
    {
        return "Gas container: " + base.ToString() + ", pressure: " + CargoPressure;
    }
}