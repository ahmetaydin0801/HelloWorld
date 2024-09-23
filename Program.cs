using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;
using AutoMapper;
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

            string computersJson = File.ReadAllText("ComputersSnake.json");

            Mapper mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ComputerSnake, Computer>()
                .ForMember(destination => destination.ComputerId, opt =>
                 opt.MapFrom(src => src.computer_id))
                .ForMember(destination => destination.Motherboard, opt =>
                    opt.MapFrom(src => src.motherboard))
                .ForMember(destination => destination.CPUCores, opt =>
                    opt.MapFrom(src => src.cpu_cores))
                .ForMember(destination => destination.HasWifi, opt =>
                    opt.MapFrom(src => src.has_wifi))
                .ForMember(destination => destination.HasLTE, opt =>
                    opt.MapFrom(src => src.has_lte))
                .ForMember(destination => destination.ReleaseDate, opt =>
                    opt.MapFrom(src => src.release_date))
                .ForMember(destination => destination.Price, opt =>
                    opt.MapFrom(src => src.price))
                .ForMember(destination => destination.VideoCard, opt =>
                    opt.MapFrom(src => src.video_card));

            }));

            IEnumerable<Computer> computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson);


            if (computersSystem != null)
            {


                foreach (Computer computer in computersSystem)
                {
                    Console.WriteLine(computer.Motherboard);
                }
            }
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            // IEnumerable<ComputerSnake>? computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<ComputerSnake>>(computersJson);

            // if (computersSystem != null)
            // {
            //     IEnumerable<Computer> computerResult = mapper.Map<IEnumerable<Computer>>(computersSystem);

            //     foreach (Computer computer in computerResult)
            //     {
            //         Console.WriteLine(computer.Motherboard);
            //     }
            // }
            // JsonSerializerOptions options = new JsonSerializerOptions
            // {
            //     PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            // };



            // IEnumerable<Computer> computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson, options);
            // IEnumerable<Computer> computersNewtonSoft = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);

            // if (computersNewtonSoft != null)
            // {
            //     foreach (Computer computer in computersNewtonSoft)
            //     {
            //         string sql = @"INSERT INTO TutorialAppSchema.Computer (
            //             Motherboard,
            //             CPUCores,
            //             HasWifi, 
            //             HasLTE,
            //             ReleaseDate,
            //             Price,
            //             VideoCard
            //         ) VALUES ('" + computer.Motherboard
            //                 + "','" + computer.CPUCores
            //                 + "','" + computer.HasWifi
            //                 + "','" + computer.HasLTE
            //                 + "','" + computer.ReleaseDate?.ToString("yyyy-MM-dd HH:mm:ss")
            //                 + "','" + computer.Price
            //                 + "','" + EscapeSingleQuotes(computer.VideoCard)
            //         + "')";

            //         dapper.ExecuteSql(sql);
            //     }
            // }




            // JsonSerializerSettings settings = new JsonSerializerSettings
            // {
            //     ContractResolver = new CamelCasePropertyNamesContractResolver()
            // };

            // string computersCopy = JsonConvert.SerializeObject(computersNewtonSoft, settings);

            // File.WriteAllText("computersCopyNewtonsoft.txt", computersCopy);

            // string computersCopySystem = System.Text.Json.JsonSerializer.Serialize(computersSystem, options);

            // File.WriteAllText("computersCopySystem.txt", computersCopySystem);


            // static string EscapeSingleQuotes(string input)
            // {
            //     return input.Replace("'", "''");
            // }
        }
    }
}
