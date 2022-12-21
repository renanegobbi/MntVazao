using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MntVazao.App.Context;
using MntVazao.App.Filters;
using MntVazao.App.Herlpers;
using MntVazao.App.Interfaces.Repository;
using MntVazao.App.Models.API;
using MntVazao.App.Repository;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace MntVazao.App
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true)
                .AddEnvironmentVariables();

            if (hostEnvironment.IsDevelopment())
            {
                //builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
               .AddHttpContextAccessor()
               .AddHttpClient();

            services.AddDbContext<MntVazaoContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection"), x => x.UseNetTopologySuite()));

            services.AddScoped<IMedicaoRepository, MedicaoRepository>();
            services.AddScoped<ISensorRepository, SensorRepository>();
            services.AddScoped<IOrganizacaoRepository, OrganizacaoRepository>();

            services
                .AddTransient(typeof(DatatablesHelper))
                .AddTransient(typeof(MedicaoFiltro))
                .AddTransient(typeof(MedicaoOrdem))
                .AddTransient(typeof(MedicaoPaginacao));

            services.AddControllersWithViews();

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            var description = "API que disponibiliza o acesso às informações de medições.<br>" +
                                "<ul>" +
                                    $"<li>Banco de dados (Sql Server): <b>MntVazao</b>.</li>" +
                                "</ul>";

            //Configurações para utilização do Swagger(Swashbuckle)
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Documentação - API MntVazao",
                    Version = "v1",
                    Description = description,
                });

                c.OperationFilter<SwaggerJsonIgnoreOperationFiltercs>();
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.ExampleFilters();
                c.EnableAnnotations();
            });

            services.AddSwaggerExamplesFromAssemblyOf<Startup>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders();

            app.UseDefaultFiles();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseHttpsRedirection();

            app.UseSwagger(c => { });

            app.UseSwaggerUI(opt =>
            {
                opt.RoutePrefix = "docs";
                opt.DefaultModelsExpandDepth(-1); // Oculta a sessão "Models"
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                opt.DocumentTitle = "Documentação - API MntVazao";
                opt.InjectStylesheet("/swagger/swagger-custom-styles.css");
                opt.InjectJavascript("/swagger/js/swagger-custom-script.js");
            });

            var cultureInfo = new CultureInfo("pt-BR");

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Graficos}/{id?}");
            });
        }
    }
}
