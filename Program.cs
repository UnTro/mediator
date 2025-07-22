
using MediatrStudying.Controllers.DItesting;
using System.Text;
//using MediatrStudying.Controllers.Moisture;
using MediatR;
using MediatrStudying.Controllers;
using MediatrStudying.Classes;
using Serilog;
namespace MediatrStudying
{
    public class Program 
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.Console().WriteTo.File("Log.txt", rollingInterval: RollingInterval.Hour, rollOnFileSizeLimit: true).CreateLogger();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterGenericHandlers = true;
                cfg.RegisterServicesFromAssembly(typeof(GenericPing<>).Assembly);
            });

            // adding serilog
            //IPipelineBehavior behavior = builder.Build();
            
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<IDItesting, DIclasses>();
            //---------------
            builder.Services.AddTransient<IMoisture, Moisture>();
           // builder.Services.AddTransient<IPressure, Pressure>();
            builder.Services.AddWeatherFeatureServices();
            builder.Services.AddTransient<Temperature>();
            builder.Services.AddTransient<IPingHandler, PingHandler>();
            builder.Services.AddTransient<IPingHandler,AnalHandler>();
            
            //---------------
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
            
            
            app.Run();

        }
    }

}
