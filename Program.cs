using System;
using System.Collections.Generic;
using System.Linq;
using HelloWorld.Models;

namespace HelloWorld
{


    public class Program
    {
        public static void Main(string[] args)
        {
            Computer myComputer = new()
            {
                Motherboard = "Asus",
                CPUCores = 8,
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 943.87m,
                VideoCard = "Nvidia"
            };

            Console.WriteLine("My computer has the following specs:");
            Console.WriteLine($"Motherboard: {myComputer.Motherboard}");
            Console.WriteLine($"CPU Cores: {myComputer.CPUCores}");
            Console.WriteLine($"Has Wifi: {myComputer.HasWifi}");
            Console.WriteLine($"Has LTE: {myComputer.HasLTE}");
            Console.WriteLine($"Release Date: {myComputer.ReleaseDate}");
        }
    }
}
