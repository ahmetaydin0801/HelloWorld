using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;
using Dapper;
using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HelloWorld
{


    public class Program
    {

        public static void Main(string[] args)
        {

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();


            DataContextDapper dapper = new DataContextDapper(config);


            // string sql = @"INSERT INTO TutorialAppSchema.Computer (
            //             Motherboard,
            //             CPUCores,
            //             HasWifi, 
            //             HasLTE,
            //             ReleaseDate,
            //             Price,
            //             VideoCard
            //         ) VALUES ('" + myComputer.Motherboard
            //         + "','" + myComputer.CPUCores
            //         + "','" + myComputer.HasWifi
            //         + "','" + myComputer.HasLTE
            //         + "','" + myComputer.ReleaseDate.ToString("yyyy-MM-dd HH:mm:ss")
            //         + "','" + myComputer.Price
            //         + "','" + myComputer.VideoCard
            // + "')";

            string computersJson = File.ReadAllText("Computers.json");

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };


            IEnumerable<Computer> computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson, options);

            IEnumerable<Computer> computersNewtonSoft = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);

            if (computersNewtonSoft != null)
            {
                foreach (Computer computer in computersNewtonSoft)
                {
                    string sql = @"INSERT INTO TutorialAppSchema.Computer (
                        Motherboard,
                        CPUCores,
                        HasWifi, 
                        HasLTE,
                        ReleaseDate,
                        Price,
                        VideoCard
                    ) VALUES ('" + computer.Motherboard
                            + "','" + computer.CPUCores
                            + "','" + computer.HasWifi
                            + "','" + computer.HasLTE
                            + "','" + computer.ReleaseDate?.ToString("yyyy-MM-dd HH:mm:ss")
                            + "','" + computer.Price
                            + "','" + EscapeSingleQuotes(computer.VideoCard)
                    + "')";

                    dapper.ExecuteSql(sql);
                }
            }




            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            string computersCopy = JsonConvert.SerializeObject(computersNewtonSoft, settings);

            File.WriteAllText("computersCopyNewtonsoft.txt", computersCopy);

            string computersCopySystem = System.Text.Json.JsonSerializer.Serialize(computersSystem, options);

            File.WriteAllText("computersCopySystem.txt", computersCopySystem);


            static string EscapeSingleQuotes(string input)
            {
                return input.Replace("'", "''");
            }
        }
    }
}
