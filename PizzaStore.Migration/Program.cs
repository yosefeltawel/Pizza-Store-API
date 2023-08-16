using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Threading.Tasks;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PizzaStore.Migration;

class Program
{
    static async Task Main(string[] args)
    {
        var upOption = new Option<bool>("--up", description: "Migrate Up", getDefaultValue: () => false);
        var downOption = new Option<long>("--down", description: "Rollback database to a version",
            getDefaultValue: () => -1);

        var rootCommand = new RootCommand("PizzaApp Fluent Migrator Runner")
        {
            upOption,
            downOption
        };

        rootCommand.Handler = CommandHandler.Create<bool, long>((up, down) =>
        {
            var serviceProvider = CreateServices();

            using (var scope = serviceProvider.CreateScope())
            {
                if (up)
                    UpdateDatabase(scope.ServiceProvider);

                else if (down > -1)
                    RollbackDatabase(scope.ServiceProvider, down);
            }
        });

        await rootCommand.InvokeAsync(args);
    }

    private static IServiceProvider CreateServices()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        var connectionString = config["connectionString"];

        return new ServiceCollection()
            // Add common FluentMigrator services
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                // Add Postgres support to FluentMigrator
                .AddSqlServer2016()
                // Set the connection string
                .WithGlobalConnectionString(connectionString)
                // Define the assembly containing the migrations
                .ScanIn(typeof(Program).Assembly).For.Migrations())
            // Enable logging to console in the FluentMigrator way
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            // Build the service provider
            .BuildServiceProvider(false);
    }

    private static void UpdateDatabase(IServiceProvider serviceProvider)
    {
        // Instantiate the runner
        var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
        // Execute the migrations
        try
        {
            runner.MigrateUp();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static void RollbackDatabase(IServiceProvider serviceProvider, long rollbackVersion)
    {
        // Instantiate the runner
        var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
        // Execute the migrations
        try
        {
            runner.MigrateDown(rollbackVersion);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}