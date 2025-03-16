using Application.Services.Hub;

using Domain.Entities;
using Microsoft.AspNetCore.SignalR;
using SignalR.Hubs;

namespace SignalR.HubServices
{
    public class NotificationHubService : INotificationHubService
    {

        readonly IHubContext<NotificationHub> _hubContext;

        public NotificationHubService(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task BroadcastMessageAsync(Notification notification)
        {
            Console.WriteLine($"SignalR ilə mesaj göndərilir: {notification.Message}");
            await _hubContext.Clients.All.SendAsync(RecieveFunctionNames.BrodcastMessage, notification);
        }
    }
}
