using System;
using System.Threading;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using SnakeWebApplication.DataBase;
using SnakeWebApplication.GameManager;

namespace SnakeWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new DataBaseController();
            // Console.WriteLine(db.RegisterUser(
            //     "hah_user12", "123")
            // );
            Console.WriteLine(db.LogInUser(
                "hah_user12", "1234")
            );
            db.SetScore("hah_user12", 123);
            db.SetScore("hah_user12", 125);
            Console.WriteLine(db.GetHighScore(
                "hah_user12")
            );

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
