using Application.Services;
using Application.Validation;
using DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GenesisBrewery2
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
