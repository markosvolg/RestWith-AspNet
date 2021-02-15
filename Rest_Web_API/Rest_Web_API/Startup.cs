using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using Rest_Web_API.Context;
using Rest_Web_API.Services;
using Rest_Web_API.Services.Implementacao;

namespace Rest_Web_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
           _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<MySqlConnection>(_ => new MySqlConnection(_configuration["MySQLConnection : MySQLConnectionString"]));

            var connection = _configuration["MySQLConnection:MySQLConnectionString"];


            services.AddDbContext<MySqlContext>(options => options.UseMySql(connection));


            //Injeção de Dependencia
            services.AddScoped<IPersonService, PersonServiceImplem>();

          
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [System.Obsolete]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "MVC1005:Cannot use UseMvc with Endpoint Routing.", Justification = "<Pendente>")]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            _ = app.UseMvc();
        }
    }
}
