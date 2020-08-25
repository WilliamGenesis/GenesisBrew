using Application.Services;
using Application.Validation;
using DataAccess;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GenesisBrew
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
            services.AddControllers();
            ConfigureApplication(services);
            ConfigureDataAccess(services);
            ConfigureContext(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureContext(IServiceCollection services)
        {
            services.AddDbContext<GenesisBrewContext>(options =>
                options.UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Database=GenesisBrew;Trusted_Connection=True;MultipleActiveResultSets=true"));
        }

        private void ConfigureApplication(IServiceCollection services)
        {
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<IWholesalerService, WholesalerService>();
            services.AddTransient<IBrandValidation, BrandValidation>();
            services.AddTransient<IWholesalerValidation, WholesalerValidation>();
        }

        private void ConfigureDataAccess(IServiceCollection services)
        {
            services.AddTransient<IBrandDataAccess, BrandDataAccess>();
            services.AddTransient<IWholesalerDataAccess, WholesalerDataAccess>();
        }
    }
}
