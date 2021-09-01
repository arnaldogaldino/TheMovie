using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using TheMovie.Application;
using TheMovie.Application.Interface;
using TheMovie.Domain.Interface.Repositories;
using TheMovie.Domain.Interface.Services;
using TheMovie.Domain.Services;
using TheMovie.Infrastructure.Data.Context;
using TheMovie.Infrastructure.Data.Repositories;
using TheMovie.Service.AutoMapper;

namespace TheMovie.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.AddDbContext<TheMovieSQLContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IFilmeRepository, FilmeRepository>();
            services.AddScoped<IFilmeAppService, FilmeAppService>();
            services.AddScoped<IFilmeService, FilmeService>();

            services.AddAutoMapper(typeof(AutoMapperConfiguration));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
            {
                options.AllowAnyHeader();
                options.AllowAnyMethod();
                options.AllowAnyOrigin();
                options.SetIsOriginAllowed(origin => true);
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            AutoMapperConfiguration.RegisterMappings();
        }
    }
}
