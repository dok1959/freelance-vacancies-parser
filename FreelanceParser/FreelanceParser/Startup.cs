using FreelanceParser.Services;
using FreelanceParser.Services.Parser;
using FreelanceParser.TelegramBot.FSM;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;

namespace FreelanceParser
{
    public class Startup
    {
        private BotConfiguration _botConfiguration;

        public Startup(IConfiguration configuration)
        {
            _botConfiguration = configuration.GetSection("BotConfiguration").Get<BotConfiguration>();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHostedService<TelegramConfigureWebhookService>();

            services.AddHttpClient("tgwebhook")
                    .AddTypedClient<ITelegramBotClient>(httpClient
                        => new TelegramBotClient(_botConfiguration.Token, httpClient));

            services.AddScoped<TelegramUpdateHandlerService>();
            services.AddSingleton<TelegramStateMachine>();
            services.AddTransient<IVacanciesParser, VacanciesParser>();

            services.AddControllers().AddNewtonsoftJson();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute
                (
                    name: "tgwebhook",
                    pattern: $"bot/{_botConfiguration.Token}",
                    new { controller = "TelegramWebhook", action = "Post" }
                );
            });
        }
    }
}
