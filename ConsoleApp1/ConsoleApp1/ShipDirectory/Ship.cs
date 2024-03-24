using ConsoleApp1.ContainersDirectory;

namespace ConsoleApp1.ShipDirectory;

public class Ship
{
    protected internal List<ContainerBase> ListOfContainers { get; set; }
    private double MaxV;
    private int MaxNumberOfContainers;
    private double MaxWeight;
    private double CurrentNumberOfContainers;
    private double CurrentWeight;
    private static int number = 0;
    private int NumberOfShip;
    public Ship(double maxV, int maxNumberOfContainers, double maxWeight)
    {
        MaxV = maxV;
        MaxNumberOfContainers = maxNumberOfContainers;
        MaxWeight = maxWeight;
        ListOfContainers = new List<ContainerBase>();
        CurrentWeight = 0;
        CurrentNumberOfContainers = 0;
        number++;
        NumberOfShip = number;

    }

    public int AddContainerOnShip(ContainerBase container)
    {
        if (MaxNumberOfContainers > CurrentNumberOfContainers)
        {
            if (CurrentWeight + container.CargoWeight/1000 + container.SoleWeight/1000 < MaxWeight)
            {
                CurrentNumberOfContainers++;
                CurrentWeight += container.CargoWeight/1000 + container.SoleWeight/1000;
                ListOfContainers.Add(container);
                Console.WriteLine("You successfully added container No. " + container.SerialNumber + " to this ship.");
                return 1;
            }
            else
            {
                Console.WriteLine("Sorry, but this container and its load is too heavy to be loaded on ship.");
                return 0;
            }
            
        }
        else
        {
            Console.WriteLine("Sorry, we can't add another container, because it will exceed the maximum amount of containers on this ship!");
            return 0;
        }
        
        
    }

    public List<ContainerBase> AddListOfContainers(List<ContainerBase> containers)
    {
        List<ContainerBase> TempList = new List<ContainerBase>(containers);
        foreach (var El in containers)
        {
            if (MaxNumberOfContainers > CurrentNumberOfContainers)
            {
                //Console.WriteLine((El.CargoWeight + El.SoleWeight) + " " + MaxWeight + " " + CurrentWeight);
                if (CurrentWeight + El.CargoWeight/1000 + El.SoleWeight/1000 < MaxWeight)
                {
                    CurrentNumberOfContainers++;
                    CurrentWeight += El.CargoWeight/1000 + El.SoleWeight/1000;
                    TempList.Remove(El);
                    ListOfContainers.Add(El);
                    Console.WriteLine("You successfully added container No. " + El.SerialNumber + " to this ship.");
                }
                else
                {
                    Console.WriteLine("Sorry, but this container and its load is too heavy to be loaded on ship.");
                }
            
            }
            else
            {
                Console.WriteLine("Sorry, we can't add another container, because it will exceed the maximum amount of containers on this ship!");
            }
            
        }

        if (TempList.Count > 0)
        {
            Console.WriteLine("Numbers of containers not added:");
            foreach (var El in TempList)
            {
                Console.WriteLine(El.SerialNumber);
            }
        }
        return TempList;
    }

    public void RemoveContainer(string number)
    {
        List<ContainerBase> tempList = new List<ContainerBase>(ListOfContainers);
        foreach (var container in ListOfContainers)
        {
            if (container.SerialNumber == number)
            {
                Console.WriteLine("You successfully removed container No. " + container.SerialNumber + " from this ship.");
                tempList.Remove(container);
            }
        }

        ListOfContainers = tempList;
        if (tempList.Count == ListOfContainers.Count)
        {
            Console.WriteLine("Sorry, this ship doesn't have such container.");
        }
    }

    /*public ContainerBase UnloadContainer(string number)
    {
        List<ContainerBase> tempList = new List<ContainerBase>(ListOfContainers);
        ContainerBase containerBase = null;
        foreach (var container in ListOfContainers)
        {
            if (container.SerialNumber == number)
            {
                containerBase = container;
                Console.WriteLine("You successfully unloaded container No. " + container.SerialNumber + " from this ship.");
                tempList.Remove(container);
            }
        }

        ListOfContainers = tempList;
        if (tempList.Count == ListOfContainers.Count)
        {
            Console.WriteLine("Sorry, this ship doesn't have such container.");
        }

        return containerBase;
    }*/

    public void ContainerFromShiptoOther(Ship otherShip)
    {
        Console.WriteLine("Choose container to move");
        foreach (var container in ListOfContainers)
        {
            Console.WriteLine(container);
        }
        string num1 = Console.ReadLine();
        ContainerBase chosenContainer = ListOfContainers[int.Parse(num1) - 1];
        int num = otherShip.AddContainerOnShip(chosenContainer);
        if (num == 1)
        {
            ListOfContainers.Remove(chosenContainer);
            Console.WriteLine("We successfully moved this container from ship to other one");
        }
        Console.WriteLine("We didn't move this container from ship to other one");
    }

    public ContainerBase ReplacingContainer(ContainerBase container)
    {
        Console.WriteLine("Choose container that will be moved");
        foreach (var cont in ListOfContainers)
        {
            Console.WriteLine(cont);
        }

        string num1 = Console.ReadLine();
        ContainerBase chosenContainer = ListOfContainers[int.Parse(num1) - 1];
        ListOfContainers[int.Parse(num1) - 1] = container;
        return chosenContainer;
    }

    public override string ToString()
    {
        String result = "Ship: " + NumberOfShip + ", max speed: " + MaxV + ", max number of containers: " + MaxNumberOfContainers + ", current number of containers: " + CurrentNumberOfContainers +
                        ", max weight of containers & cargo: " + MaxWeight + ", current weight of containers & cargo: " + CurrentWeight + ", list of containers={";
        foreach (var container in ListOfContainers)
        {
            result += container.SerialNumber + " ";
        }
        result = result.Trim();
        
        return result + "}";
    }
}