namespace ConsoleApp1.ContainersDirectory.LiquidContainers;

public class LiquidContainer : ContainerBase
{
    public LiquidContainer(double cargoWeight, double height, double soleWeight, double depth, string serialNumber, double maxPayload) : base(cargoWeight, height, soleWeight, depth, serialNumber, maxPayload)
    {}

    public override void ReloadingContainers(double Cargo)
    {
        if (Cargo > MaxPayload)
        {
            //todo
            throw new NotImplementedException();
        }
    }
}