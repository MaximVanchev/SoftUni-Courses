using System;
using System.Collections.Generic;
using System.Linq;

namespace VehiclesExtension
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Car car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]), double.Parse(carInput[3]));
            string[] truckInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Truck truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]), double.Parse(truckInput[3]));
            string[] busInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Bus bus = new Bus(double.Parse(busInput[1]), double.Parse(busInput[2]), double.Parse(busInput[3]));
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (input[0] == "Drive")
                {
                    if (input[1] == "Car")
                    {
                        car.Drive(double.Parse(input[2]));
                    }
                    else if (input[1] == "Bus")
                    {
                        bus.Drive(double.Parse(input[2]));
                    }
                    else
                    {
                        truck.Drive(double.Parse(input[2]));
                    }
                }
                else if (input[0] == "Refuel")
                {
                    try
                    {
                        if (input[1] == "Car")
                        {
                            car.Refuel(double.Parse(input[2]));
                        }
                        else if (input[1] == "Bus")
                        {
                            bus.Refuel(double.Parse(input[2]));
                        }
                        else
                        {
                            truck.Refuel(double.Parse(input[2]));
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    continue;
                }
                else if (input[0] == "DriveEmpty")
                {
                    if (input[1] == "Car")
                    {
                        car.Drive(double.Parse(input[2]));
                    }
                    else if (input[1] == "Bus")
                    {
                        bus.DriveEmpty(double.Parse(input[2]));
                    }
                    else
                    {
                        truck.Drive(double.Parse(input[2]));
                    }
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
