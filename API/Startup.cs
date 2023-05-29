using API.Extensions;
using API.Helpers;
using API.Middleware;
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

            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddControllers();
            services.AddDbContext<StoreContext>(x =>
                x.UseSqlite(_config.GetConnectionString("DefaultConnection")));

            services.AddApplicationServices();
            services.AddSwaggerDocumentation();
        }

            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                app.UseMiddleware<ExceptionMiddleware>();

                app.UseStatusCodePagesWithReExecute("/errors/{0}");

                app.UseHttpsRedirection();

                app.UseRouting();

                app.UseStaticFiles();

                app.UseAuthorization();

                app.UseSwaggerDocumentation();

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            }
    }
}