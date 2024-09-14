using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorld
{
    public class Computer
    {
        public string Motherboard { get; set; } = "";
        public int CPUCores { get; set; }
        public bool HasWifi { get; set; }
        public bool HasLTE { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public string VideoCard { get; set; } = "";

        // Constructor without null checks since default values are already set
        public Computer() { }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Computer myComputer = new Computer()
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
