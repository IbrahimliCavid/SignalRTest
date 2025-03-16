using Application.Dtos;

namespace Application.Services
{
    public interface INotificationService
    {
        public Task<bool> SendNotificationAllClient(NotificationDto notification);
    }
}
