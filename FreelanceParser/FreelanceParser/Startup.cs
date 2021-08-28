using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;

namespace FreelanceParser
{
    public class Startup
    {
        private BotConfiguration _botConfiguration;
        public void ConfigureServices(IServiceCollection services)
        {
            _botConfiguration = new BotConfiguration
            {
                Token = "",
                HostAddress = ""
            };

            ITelegramBotClient botClient = new TelegramBotClient(_botConfiguration.Token);

            string hook = $"{_botConfiguration.HostAddress}/bot/{_botConfiguration.Token}";
            botClient.SetWebhookAsync(hook).Wait();

            services.AddScoped(client => botClient);

            services.AddControllers();
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
                endpoints.MapControllers();
            });
        }
    }
}
