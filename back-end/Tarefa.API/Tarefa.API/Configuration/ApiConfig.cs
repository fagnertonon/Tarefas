using Microsoft.EntityFrameworkCore;
using Tarefas.Data;
namespace Tarefas.API.Configuration
{
    public static class ApiConfig
    {
        public static async void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration, IHostEnvironment env)
        {
            services.AddDbContext<ApplicationContext>(options =>
                 options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly("Tarefas.Data")));

            services.AddControllers().AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddCors(options =>
            {
                options.AddPolicy("Total",
                    builder =>
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
            });
        }

        public static void UseApiConfiguration(this WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationContext>();
                context.Database.Migrate();
            }
            //AsseguraDBExiste(app.Services);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("Total");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        public static async Task AsseguraDBExiste(IServiceProvider services)
        {
            using var db = services.CreateScope().ServiceProvider.GetRequiredService<ApplicationContext>();
            await db.Database.EnsureCreatedAsync();
            await db.Database.MigrateAsync();
        }

    }
}