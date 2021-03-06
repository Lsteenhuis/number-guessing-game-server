using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Server.Database;
using Server.Database.Interfaces;
using Server.GameMetaData;
using Server.GameMetaData.interfaces;
using Server.GameMetaData.repositories;
using Server.GameMetaData.services;

namespace Server {
  public class Startup {
    private const string AllowAll = "AllowAll";

    public Startup(IConfiguration configuration) {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services) {
      services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Server", Version = "v1"}); });
      services.AddControllers();
      
      services.AddSingleton<IDatabasePool, DatabasePool>();
      
      services.AddScoped<IGameMetaDataController, GameMetaDataController>();
      services.AddTransient<IGameMetaDataRepository, GameMetaDataRepository>();
      services.AddTransient<IGuessingSpeedRepository, GuessingSpeedRepository>();
      services.AddTransient<IAmountOfGuessesRepository, AmountOfGuessesRepository>();
      services.AddTransient<IMetaDataCalculator, MetaDataCalculator>();
       
      services.AddRazorPages();


      services.AddCors(options => {
        options.AddPolicy(AllowAll,
          builder => {
            builder.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
          });
      });
      // services.AddMvc(options => options.EnableEndpointRouting = false);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Server v1"));
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseCors(AllowAll);

      app.UseAuthorization();
      app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
  }
}