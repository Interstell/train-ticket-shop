using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Routing;
using TrainTicketShop.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Net.Http;
using TrainTicketShop.Services;
using StackExchange.Redis;
using TrainTicketShop.Services.SessionId;

namespace TrainTicketShop {
    public class Startup {
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env) {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc();
            services.AddSingleton(Configuration);
            services.AddDbContext<TrainTicketShopDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("LocalDB")));
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<TrainTicketShopDbContext>();

            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddSingleton(new HttpClient(new HttpClientHandler {
                UseProxy = false
            }));
            services.AddScoped<SearchHintsService>();
            services.AddSingleton(ConnectionMultiplexer.Connect(Configuration.GetConnectionString("Redis")));
            services.AddScoped<CacheService>();

            services.AddSingleton<PbSessionIdService>(); //todo interfaces
            services.AddScoped<SearchTrainService>();
            services.AddScoped<TrainInfoService>();
            services.AddScoped<CarriageInfoService>();

            services.AddScoped<ICarriageSchemaData, CarriageSchemaData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                            IHostingEnvironment env,
                            ILoggerFactory loggerFactory) {
            loggerFactory
                .AddConsole();

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler(new ExceptionHandlerOptions {
                    ExceptionHandler = context => context.Response.WriteAsync("Oops!")
                });
            }

            app.UseFileServer();

            app.UseIdentity();

            app.UseMvc(ConfigureRoutes);
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder) {
            routeBuilder.MapRoute("Default",
                "{controller=Search}/{action=Index}");
        }
    }
}
