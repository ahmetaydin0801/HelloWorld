using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;

namespace HelloWorld
{


    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=True;Trusted_Connection=False;User Id=sa;Password=SQLConnect1";

            IDbConnection dbConnection = new SqlConnection(connectionString);

            string sqlCommand = "SELECT GETDATE()";

            DateTime rightNow = dbConnection.QuerySingle<DateTime>(sqlCommand);

            Console.WriteLine($"The current date and time is: {rightNow}");

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

            string sql = @"INSERT INTO TutorialAppSchema.Computer (
                Motherboard
                CPUCores
                HasWifi
                HasLTE,
                ReleaseDate
                Price
                VideoCard
            ) VALUES ('" + myComputer.Motherboard
                    + "','" + myComputer.CPUCores
                    + "','" + myComputer.HasWifi
                    + "','" + myComputer.HasLTE
                    + "','" + myComputer.ReleaseDate
                    + "','" + myComputer.Price
                    + "','" + myComputer.VideoCard
            + "')";

            Console.WriteLine(sql);

            int result = dbConnection.Execute(sql);

            Console.WriteLine(result);
        }
    }
}
