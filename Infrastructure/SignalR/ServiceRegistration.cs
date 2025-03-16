using Application.Services.Hub;
using Microsoft.Extensions.DependencyInjection;
using SignalR.HubServices;

namespace SignalR
{
    public static class ServiceRegistration
    {
        public static void AddSignalRServices(this IServiceCollection services)
        {
            services.AddTransient<INotificationHubService, NotificationHubService>();

            services.AddSignalR();
        }
    }
}
