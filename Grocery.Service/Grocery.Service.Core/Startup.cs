using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Grocery.BLL.Contract;
using Grocery.BLL.Rules;
using System.Configuration;
using Grocery.Service.Configuration;

namespace Grocery.Service.Core
{
    public class Startup
    {
        //Конфигурация служб для промежуточного ПО и установка пользователя по заданому логину на сервис
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();

            string constringname = ConfigurationManager.ConnectionStrings["GroceryDBCon"].ConnectionString;

            try
            {
                if (constringname.Length > 0)
                {
                    services.AddSingleton<IValidationRuleFactory>(new ValidationRuleFactory());
                    services.AddSingleton<HubEnvironment>();
                }
                else if (constringname.Length == 0)
                {
                    throw new Exception("There is no connection string!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Установка и настройка маршрута при добавлении функционала SignalR в приложение
        public void Configure(IApplicationBuilder app)
        {
            app.UseSignalR(routes =>
            {
                routes.MapHub<MainHub>("/" + ServiceSettings.HubName);
            });
        }
    }
}
