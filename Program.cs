using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;

namespace HelloWorld
{


    public class Program
    {
        public static void Main(string[] args)
        {
            DataContextDapper dapper = new DataContextDapper();
            DataContextEF ef = new DataContextEF();

            string sqlCommand = "SELECT GETDATE()";

            DateTime rightNow = dapper.LoadDataSingle<DateTime>(sqlCommand);

            Console.WriteLine($"Th e current date and time is: {rightNow}");

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

            ef.Add(myComputer);
            ef.SaveChanges();

            string sql = @"INSERT INTO TutorialAppSchema.Computer (
                        Motherboard,
                        CPUCores,
                        HasWifi,
                        HasLTE,
                        ReleaseDate,
                        Price,
                        VideoCard
                    ) VALUES ('" + myComputer.Motherboard
                    + "','" + myComputer.CPUCores
                    + "','" + myComputer.HasWifi
                    + "','" + myComputer.HasLTE
                    + "','" + myComputer.ReleaseDate.ToString("yyyy-MM-dd HH:mm:ss")
                    + "','" + myComputer.Price
                    + "','" + myComputer.VideoCard
            + "')";

            Console.WriteLine(sql);

            bool result = dapper.ExecuteSql(sql);

            Console.WriteLine(result);


            string sqlSelect = @"
             SELECT
                Computer.ComputerId,
                Computer.Motherboard,
                Computer.CPUCores,
                Computer.HasWifi,
                Computer.HasLTE,
                Computer.ReleaseDate,
                Computer.Price,
                Computer.VideoCard
             FROM TutorialAppSchema.Computer";


            IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);


            // Console.WriteLine("Computers in the database:");
            // foreach (Computer computer in computers)
            // {
            //     Console.WriteLine($"Motherboard: {computer.Motherboard}");
            //     Console.WriteLine($"CPU Cores: {computer.CPUCores}");
            //     Console.WriteLine($"Has Wifi: {computer.HasWifi}");
            //     Console.WriteLine($"Has LTE: {computer.HasLTE}");
            //     Console.WriteLine($"Release Date: {computer.ReleaseDate}");

            // }

            IEnumerable<Computer>? computersEf = ef.Computer?.ToList<Computer>();

            if (computersEf != null)
            {
                Console.WriteLine("Computers in the database:");
                foreach (Computer computer in computersEf)
                {
                    Console.WriteLine($"ComputerId: {computer.ComputerId}");
                    Console.WriteLine($"Motherboard: {computer.Motherboard}");
                    Console.WriteLine($"CPU Cores: {computer.CPUCores}");
                    Console.WriteLine($"Has Wifi: {computer.HasWifi}");
                    Console.WriteLine($"Has LTE: {computer.HasLTE}");
                    Console.WriteLine($"Release Date: {computer.ReleaseDate}");

                }
            }


        }
    }
}
