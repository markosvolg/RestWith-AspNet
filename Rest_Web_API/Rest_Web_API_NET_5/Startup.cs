using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rest_Web_API.Context;
using Rest_Web_API_NET_5.Business;
using Rest_Web_API_NET_5.Business.Implementacao;
using Rest_Web_API_NET_5.Repository;
using Rest_Web_API_NET_5.Repository.Generic;
using Rest_Web_API_NET_5.Repository.Implementacao;
using Serilog;
using System;
using System.Collections.Generic;

namespace Rest_Web_API_NET_5
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }

     

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

           var connection = Configuration["MySQLConnection:MySQLConnectionString"];

            services.AddDbContext<MySqlContext>(options => options.UseMySql(connection));


            //if (Environment.IsDevelopment())
            //{
            //    MigrateDatabase(connection);
            //}

            //Versionamento de API
            services.AddApiVersioning();

            //Injeção de Dependencia
            services.AddScoped<IPersonBusiness, PersonBusinessImplem>();
            services.AddScoped<IPersonRepository, PersonRepositoryImplem>();
            services.AddScoped<IBookBusiness, BookBusinessImplement>();
           // services.AddScoped<IBookRepository, BookRepositoryImplement>();

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rest_Web_API_NET_5", Version = "v1" });
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //    app.UseSwagger();
            //    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rest_Web_API_NET_5 v1"));
            //}

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void MigrateDatabase(string connection)
        {  
            try
            {
                var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connection);
                var evolve = new Evolve.Evolve(evolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string> { "db/migrations", "db/dataset" },
                    IsEraseDisabled = true,
                };

                evolve.Migrate();

            }
            catch (Exception ex)
            {
                Log.Error("Falha na conexao do Banco de Dados", ex);
                throw;
            }
        }
    }

   
}
