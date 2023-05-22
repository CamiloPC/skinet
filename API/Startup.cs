using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Startup 
    {
        private readonly IConfiguration _config;
        
        public Startup(IConfiguration config) 
        {
            _config = config;
        }


        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddControllers();
            services.AddDbContext<StoreContext>(x => 
                x.UseSqlite(_config.GetConnectionString("DefaultConnection")));
        }
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
   
    }
}