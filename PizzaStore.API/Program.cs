using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PizzaStore.API;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

StartupHelpers.ConfigureLLBLGen(services, configuration);
services.AddControllers();
ServiceRegistrations.Register(services);
services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "PizzaStoreAPI", Version = "v1"}); });
services.AddHttpClient();

var app = builder.Build();


app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
}

app.Run();