using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.IO;
using Goalsy.Objectives;
using Goalsy.Components;

namespace Goalsy
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            // Create and configure Serilog
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            Log.Logger.Information("Application starting");

            // Create and configure host
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<Application>();
                })
                .UseSerilog()
                .Build();

            // Application entry point
            var svc = ActivatorUtilities.CreateInstance<Application>(host.Services);
            svc.Run();
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
        }
    }

    public class Application
    {
        private readonly ILogger<Application> _logger;
        private readonly IConfiguration _config;

        public Application(ILogger<Application> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public void Run()
        {
            _logger.LogInformation("Application started");
            Console.WriteLine("Welcome to Goalsy!");
            //CreateGoal("Get whiter teeth",0,0,0);
            //CreateGoal("Learn to whistle");
            IObjective mygoal = new TestGoal("Get whiter teeth");
            ITimer timerComp = new CountdownTimer(0, 0, 10);
            mygoal.AttachComponent(timerComp);
            Console.WriteLine(mygoal.Description);
            timerComp.Start();

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}
