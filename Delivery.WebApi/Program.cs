using System.Text.Json.Serialization;
using Delivery.WebApi.Middleware;
using Delivery.WebApi.StartupExtensions;

namespace Delivery.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddServices();
            builder.Services.AddMapper();
            builder.Services.AddAuthenticationAndAuthorizationConfiguration(builder.Configuration);
            builder.Services.AddSwagger();
            builder.Services.AddCorsToServices();
            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(x => x.EnablePersistAuthorization());
            }
            else
            {
                app.UseMiddleware<ExceptionHandlingMiddleware>();
            }
            
            app.UseHsts();
            app.UseHttpsRedirection();
            
            app.UseCors("DeliveryCorsPolicy");
            
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.MapControllers();
            
            app.Run();
        }
    }
}