using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieRatingApi.Data;
using System.IO;

namespace MovieRatingApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "ApiPolicy",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                                .WithMethods("PUT", "POST", "GET");
                    });
            });

            services.AddControllers();

            string path = Directory.GetCurrentDirectory();
            services.AddDbContext<MovieRatingApiContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")
                  .Replace("[DataDirectory]", path)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
