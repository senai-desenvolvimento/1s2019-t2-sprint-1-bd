using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Senai.HRoads.Domain.Interfaces;
using Senai.HRoads.Infra.Data.Repositorios;
using System;
using System.IO;
using System.Reflection;

namespace Senai.HRoads.Web.Api
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

            services.AddScoped<IClassesRepositorio, ClassesRepositorio>();
            services.AddScoped<ITiposHabilidadesRepositorio, TiposHabilidadesRepositorio>();
            services.AddScoped<IHabilidadesRepositorio, HabilidadesRepositorio>();
            services.AddScoped<IPersonagensRepositorio, PersonagensRepositorio>();
            services.AddScoped<IClassesHabilidadesRepositorio, ClassesHabilidadesRepositorio>();

            // Configurando o serviço de documentação do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "HRoads",
                        Version = "v1",
                        Description = "Exemplo de API REST criada com o ASP.NET Core"
                    });

                string caminhoXmlDoc = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.XML");

                c.IncludeXmlComments(caminhoXmlDoc);
            });

            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                    .AddJsonOptions(options => {
                        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    }); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.UseSwagger();

            //This line enables Swagger UI, which provides us with a nice, simple UI with which we can view our API calls.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HRoads XML Api Beta v1");
            });
        }
    }
}
