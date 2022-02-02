using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<PetrolPumps> petrolPumps = new Queue<PetrolPumps>();           
            int petrolTank = 0;
            int petrolPumpIndex = 0;
            int petrolPumpsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < petrolPumpsCount; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                PetrolPumps newPetrolPump = new PetrolPumps(input[0], input[1]);
                petrolPumps.Enqueue(newPetrolPump);
            }
            Queue<PetrolPumps> petrolPumpsTwo = petrolPumps;
            for (int i = 0; i < petrolPumpsCount; i++)
            {
                petrolPumpIndex = i;
                petrolPumps = petrolPumpsTwo;
                for (int z = 0; z < i; z++)
                {
                    petrolPumps.Enqueue(petrolPumps.Dequeue());
                }
                for (int a = 0; a < petrolPumpsCount; a++)
                {
                    if (petrolPumps.Peek().Petrol + petrolTank >= petrolPumps.Peek().Distance)
                    {
                        petrolTank = petrolPumps.Peek().Petrol - petrolPumps.Peek().Distance;
                        petrolPumps.Enqueue(petrolPumps.Dequeue());
                    }
                    else
                    {
                        petrolPumps.Enqueue(petrolPumps.Dequeue());
                        petrolTank = 0;
                        break;
                    }
                    i = petrolPumpsCount;
                    break;
                }  
            }
            Console.WriteLine(petrolPumpIndex);
        }
        public class PetrolPumps
        {
            public int Petrol { get; set; }
            public int Distance { get; set; }
            public PetrolPumps(int petrol,int distance)
            {
                Petrol = petrol;
                Distance = distance;
            }
        }
    }
}
