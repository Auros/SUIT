using SUIT.Services;
using System.Net.Http;
using SUIT.Models.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SUIT
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
            => _configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            var deploymentSettings = _configuration.GetSection(nameof(DeploymentSettings)).Get<DeploymentSettings>();
            var discordConfig = _configuration.GetSection(nameof(AuthorizationSettings));
            services.Configure<AuthorizationSettings>(discordConfig);

            services.AddSingleton<IAuthorizationSettings>(ii => ii.GetRequiredService<IOptions<AuthorizationSettings>>().Value);

            services.AddSingleton<HttpClient>();
            services.AddSingleton<SteamService>();
            services.AddSingleton<TwitchService>();
            services.AddSingleton<DiscordService>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: "_allowSUITOrigins", opt =>
                {
                    opt.WithOrigins(deploymentSettings.CORS)
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("_allowSUITOrigins");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("SUIT OK!");
                });
                endpoints.MapGet("/api", async context =>
                {
                    await context.Response.WriteAsync("SUIT OK!");
                });
                endpoints.MapControllers();
                endpoints.MapFallback(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    await context.Response.WriteAsync("Not Found");
                });
            });
        }
    }
}
