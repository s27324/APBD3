using ConsoleApp1.ContainersDirectory;
using ConsoleApp1.ShipDirectory;

class Program
{
    static List<ContainerBase> ContainerList = new List<ContainerBase>();
    static List<Ship> ShipList = new List<Ship>();
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("List of container ships:");
            if (ShipList.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (var ship in ShipList)
                {
                    Console.WriteLine(ship);
                }
            }
            Console.WriteLine();
            
            Console.WriteLine("List of containers:");
            if (ContainerList.Count == 0)
            {
                Console.WriteLine("None");
            }
            else
            {
                foreach (var container in ContainerList)
                {
                    Console.WriteLine(container);
                }
            }
            Console.WriteLine();
            int position = 0;
            
            Console.WriteLine("Possible actions:\n1. Add container ship");
            Console.WriteLine("2. Remove container ship\n3. Add container");
            Console.WriteLine("4. Place the container on the ship\n5. Remove container from ship");
            Console.WriteLine("6. Load cargo into container\n7. Unload cargo from container");
            Console.WriteLine("8. Move a container between 2 ships.\n9. Replace a container by another one in specificed ship\n\nChoose number from the actions:");
        
            string chosen = Console.ReadLine();
        
            switch (chosen)
            {
                case "1":
                {
                    Console.WriteLine("Type max speed of the ship, max number of containers and max weight of cargo & containers:");
                    string[] parameters = Console.ReadLine().Split(" ");
        
                    Ship newShip = new Ship(double.Parse(parameters[0]), int.Parse(parameters[1]), double.Parse(parameters[2]));
                    ShipList.Add(newShip);
                    Console.WriteLine("New ship was created.");
        
                    break;
                }
                case "2":
                {
                    Console.WriteLine("Choose which ship must be removed:");
                    foreach (var ship in ShipList)
                    {
                        Console.WriteLine(ship);
                    }

                    string num = Console.ReadLine();
                    ShipList.RemoveAt(int.Parse(num) - 1);
                    break;
                }
                case "3":
                {
                    Console.WriteLine("What type of container you want?\n[c] - cooled\n[g] - gas\n[l] - liquid");
                    string type = Console.ReadLine();
                    switch (type)
                    {
                        case "c":
                        {
                            Console.WriteLine(
                                "Type cargo weight, height of container, sole weight of container, depth of container, max payload and product type");
                            string[] parameters = Console.ReadLine().Split(" ");
                            CooledContainer container = new CooledContainer(double.Parse(parameters[0]),
                                double.Parse(parameters[1]), double.Parse(parameters[2]),
                                double.Parse(parameters[3]), double.Parse(parameters[4]), parameters[5]);
                            ContainerList.Add(container);
                            Console.WriteLine("Cooled container added successfully.");
                            break;
                        }
                        case "g":
                        {
                            Console.WriteLine(
                                "Type cargo weight, height of container, sole weight of container, depth of container, max payload and cargo pressure");
                            string[] parameters = Console.ReadLine().Split(" ");
                            GasContainer container = new GasContainer(double.Parse(parameters[0]),
                                double.Parse(parameters[1]), double.Parse(parameters[2]),
                                double.Parse(parameters[3]), double.Parse(parameters[4]), double.Parse(parameters[5]));
                            ContainerList.Add(container);
                            Console.WriteLine("Gas container added successfully.");
                            break;
                        }
                        case "l":
                        {
                            Console.WriteLine(
                                "Type cargo weight, height of container, sole weight of container, depth of container, max payload and \"true\" or \"false\" if it is hazardous");
                            string[] parameters = Console.ReadLine().Split(" ");
                            LiquidContainer container = new LiquidContainer(double.Parse(parameters[0]),
                                double.Parse(parameters[1]), double.Parse(parameters[2]),
                                double.Parse(parameters[3]), double.Parse(parameters[4]), bool.Parse(parameters[5]));
                            ContainerList.Add(container);
                            Console.WriteLine("Liquid container added successfully.");
                            break;
                        }
                        default:
                        {
                            Console.WriteLine("There is no such type. Please select from: cooled, gas or liquid.");
                            break;
                        }
                    }
                    break;
                }
                case "4":
                {
                    Console.WriteLine("Choose container ship:");
                    foreach (var ship in ShipList)
                    {
                        Console.WriteLine(ship);
                    }
                    string num1 = Console.ReadLine();
                    Console.WriteLine("\nChoose container [1] or multiple containers: [2]");
                    string num2 = Console.ReadLine();
                    if (num2 == "1")
                    {
                        foreach (var container in ContainerList)
                        {
                            Console.WriteLine(container);
                        }
                        string num3 = Console.ReadLine();
                        int result = ShipList[int.Parse(num1) - 1].AddContainerOnShip(ContainerList[int.Parse(num3) - 1]);
                        if (result == 1)
                        {
                            ContainerList.RemoveAt(int.Parse(num3) - 1);
                        }
                        
                    } 
                    else if (num2 == "2")
                    {
                        List<ContainerBase> tempList = new List<ContainerBase>();
                        foreach (var container in ContainerList)
                        {
                            Console.WriteLine(container);
                        }
                        string[] num3 = Console.ReadLine().Split(" ");
                        
                        List<ContainerBase> tempContainer = new List<ContainerBase>();
                        for (int i = 0; i < num3.Length; i++)
                        {
                            tempContainer.Add(ContainerList[int.Parse(num3[i]) - 1]);
                        }

                        List<ContainerBase> result = new List<ContainerBase>(ContainerList);
                        result.RemoveAll(element => tempContainer.Contains(element));
                        result.AddRange(ShipList[int.Parse(num1) - 1].AddListOfContainers(tempContainer));
                        
                        ContainerList = result;
                    }

                    break;
                }
                case "5":
                {
                    Console.WriteLine("Choose container ship");
                    foreach (var ship in ShipList)
                    {
                        Console.WriteLine(ship);
                    }
                    string num1 = Console.ReadLine();
                    Console.WriteLine("Choose container");
                    foreach (var container in ShipList[int.Parse(num1) - 1].ListOfContainers)
                    {
                        Console.WriteLine(container);
                    }

                    string num2 = Console.ReadLine();
                    ContainerBase temp = ShipList[int.Parse(num1) - 1].ListOfContainers[int.Parse(num2) - 1];
                    ContainerList.Add(temp);
                    ShipList[int.Parse(num1) - 1].RemoveContainer(ShipList[int.Parse(num1) - 1].ListOfContainers[int.Parse(num2) - 1].SerialNumber);
                    break;
                }
                case "6":
                {
                    Console.WriteLine("Choose container");
                    foreach (var container in ContainerList)
                    {
                        Console.WriteLine(container);
                    }

                    string num1 = Console.ReadLine();
                    Console.WriteLine("Specify how much cargo you want to load");
                    double loadNumber = double.Parse(Console.ReadLine());
                    ContainerList[int.Parse(num1) - 1].ReloadingContainers(loadNumber);
                    break;
                }
                case "7":
                {
                    Console.WriteLine("Choose container");
                    foreach (var container in ContainerList)
                    {
                        Console.WriteLine(container);
                    }

                    string num1 = Console.ReadLine();
                    ContainerList[int.Parse(num1) - 1].EmptyingContainer();
                    break;
                }
                case "8":
                {
                    Console.WriteLine("Choose container ship from which the container is to be moved");
                    foreach (var ship in ShipList)
                    {
                        Console.WriteLine(ship);
                    }
                    string num1 = Console.ReadLine();
                    Console.WriteLine("Choose container ship from to the container is to be moved");
                    foreach (var ship in ShipList)
                    {
                        Console.WriteLine(ship);
                    }
                    string num2 = Console.ReadLine();
                    ShipList[int.Parse(num1) - 1].ContainerFromShiptoOther(ShipList[int.Parse(num2) - 1]);
                    break;
                }
                case "9":
                {
                    Console.WriteLine("Choose container which will be moved on container");
                    foreach (var container in ContainerList)
                    {
                        Console.WriteLine(container);
                    }
                    string num1 = Console.ReadLine();
                    ContainerBase containerToBeMoved = ContainerList[int.Parse(num1) - 1];
                    
                    Console.WriteLine("Choose container ship");
                    foreach (var ship in ShipList)
                    {
                        Console.WriteLine(ship);
                    }
                    string num2 = Console.ReadLine();
                    Ship tempShip = ShipList[int.Parse(num2) - 1];
                    ContainerBase returnedContainer = tempShip.ReplacingContainer(containerToBeMoved);
                    ContainerList[int.Parse(num1) - 1] = returnedContainer;
                    Console.WriteLine("Successful swap");
                    break;
                }
            }
        }
    }
}


