using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using DBStoreContext.Models;
using Newtonsoft.Json.Serialization;
using OnlineStoreBusinessLayer.Interfaces;
using OnlineStoreBusinessLayer;
using Microsoft.Extensions.Logging;
using System.IO;

namespace OnlineStoreUi
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

      services.AddDbContext<OnlineStoreDBContext>();
      //services.AddSwaggerGen(c =>
      //{
      //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "OnlineStoreUi", Version = "v1" });
      //});

      services.AddScoped<IOrderRepository, OrderRepository>();
      services.AddScoped<IModelMapper, ModelMapper>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
    {
      loggerFactory.AddFile("Logs/app-{Date}.txt");

      app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        //app.UseSwagger();
        //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OnlineStoreUi v1"));
      }

      app.UseStatusCodePages();

      app.UseDefaultFiles();
      app.UseStaticFiles();

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
