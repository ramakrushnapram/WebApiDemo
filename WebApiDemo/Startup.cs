using BookStoreData.Interfaces;
using BookStoreData.Models;
using BookStoreData.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo
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
            services.AddScoped<IBookInterface, BookBataBase>();
            var connection = @" Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Lenovo\Documents\BookStore.mdf; Integrated Security = True; Connect Timeout = 30";

            services.AddDbContext<BookStoreContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
             app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

                //app.UseCors(options => options.WithOrigins("http://localhost:59052")
                //.AllowAnyMethod()
                //.AllowAnyHeader()
                //.AllowAnyOrigin()

                //);
                app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //for dropping and recreating database

            using(var serviceScope =app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
             {
                var context = serviceScope.ServiceProvider.GetRequiredService<BookStoreContext>();
                context.Database.EnsureCreated();
            }
        }
    }
}
