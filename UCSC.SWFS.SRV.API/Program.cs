using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UCSC.SWFS.SRV.API.Insfrastructure;
using UCSC.SWFS.SRV.Entity.Context;
using UCSC.SWFS.SRV.Service.Common;
using UCSC.SWFS.SRV.Service.Common.SignalIR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<SWFSDbContext>();
builder.Services.AddAppDependencies();
builder.Services.AddHostedService<BackgroundSchedulerService>();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CorsPolicy");

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<SensorDataHub>("/data-hub");
});

app.Run();
