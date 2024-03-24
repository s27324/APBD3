using System.Data;
using ConsoleApp1.Exceptions;

namespace ConsoleApp1.ContainersDirectory;

public class CooledContainer : ContainerBase
{
    private string ProductType;
    private double TempInside;

    private Dictionary<string, double> ListOfProducts = new Dictionary<string, double>()
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18 },
        { "Fish", 2 },
        { "Meat", -15 },
        { "Ice cream", -18 },
        { "Frozen pizza", -30 },
        { "Cheese", 7.2 },
        { "Sausages", 5 },
        { "Butter", 20.5 },
        { "Eggs", 19 }
    };
    public CooledContainer(double cargoWeight, double height, double soleWeight, double depth, double maxPayload, string productType) : base(cargoWeight, height, soleWeight, depth, maxPayload)
    {
        ProductType = productType;
        TempInside = ListOfProducts[ProductType];
    }

    public override void ReloadingContainers(double cargo)
    {
        try
        {
            if (cargo + CargoWeight > MaxPayload)
            {
                throw new OverfillException("Adding this cargo will exceed the container maximum payload!\nInstead, we filled this container to its maximum.");
            }

            while (true)
            {
                Console.WriteLine("Choose one of the following types you want to add and type it in terminal:");
                foreach (var El in ListOfProducts)
                {
                    Console.WriteLine("[" + El.Key + "] " + El.Value);
                }
                string ChosenProduct = Console.ReadLine();
                if (ListOfProducts.ContainsKey(ChosenProduct))
                {
                    if (ProductType == ChosenProduct)
                    {
                        CargoWeight += cargo;
                        Console.WriteLine("Added a load weighing " + cargo + " kg to container No. " + SerialNumber);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, but this container is used for different type of products.");
                    }
                }
                else
                {
                    Console.WriteLine("Our containers can't transport such products. Please try different!");
                }
            }
            
        }
        catch (OverfillException e)
        {
            CargoWeight = MaxPayload;
            Console.WriteLine("Error: " + e.Message);
        }
    }

    public override void EmptyingContainer()
    {
        CargoWeight = 0;
        Console.WriteLine("Container No. " + SerialNumber + " was emptied.");
    }
}