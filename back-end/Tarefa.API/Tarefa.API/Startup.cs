using MediatR;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Tarefas.API.Configuration;

namespace Tarefas.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            env = hostEnvironment;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IHostEnvironment env { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddApiConfiguration(Configuration, env);

            services.AddMediatR(typeof(Startup));

            services.RegisterServices();

            services.AddMessageBusConfiguration(Configuration);
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseApiConfiguration(env);

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
