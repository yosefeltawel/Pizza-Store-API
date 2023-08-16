using System.Diagnostics;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaStore.Data.DatabaseSpecific;
using SD.LLBLGen.Pro.DQE.SqlServer;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace PizzaStore.API;

public static class StartupHelpers
{
    public static void ConfigureLLBLGen(IServiceCollection services, IConfiguration config)
    {
        RuntimeConfiguration.AddConnectionString("ConnectionString.SQL Server (SqlClient)", config.GetConnectionString("SqlServer"));
        RuntimeConfiguration.ConfigureDQE<SQLServerDQEConfiguration>(c =>
        {
            c.AddDbProviderFactory(typeof(SqlClientFactory));
            c.SetTraceLevel(TraceLevel.Verbose);
        });

        services.AddScoped<DataAccessAdapter>();
    }
}