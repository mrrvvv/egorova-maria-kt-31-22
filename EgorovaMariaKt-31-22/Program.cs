using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using EgorovaMariaKt_31_22.Database;
using static EgorovaMariaKt_31_22.ServiceExtensions.ServiceExtensions;

using System.Text.Json.Serialization;
using EgorovaMariaKt_31_22.Middlewares;
{

    var builder = WebApplication.CreateBuilder(args);
    var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

    try
    {
        builder.Logging.ClearProviders();
        builder.Host.UseNLog();
        // Add services to the container.

        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<LessonDbContext>(option =>
        option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddServices();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseMiddleware<ExceptionHandlerMiddleware>();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
    catch (Exception ex)
    {
        logger.Error(ex, "Stopped program because of exception");
    }
    finally
    {
        LogManager.Shutdown();
    }
}