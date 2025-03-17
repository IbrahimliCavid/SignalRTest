using Application.Dtos;

namespace Application.Services
{
    public interface INotificationService
    {
        public Task<bool> SendNotificationAllClient(CreateNotificationDto notification);
        public Task<List<GetNotificationDto>> GetUnreadNotifications(List<string> messageIds);
        Task MarkMessagesAsReadAsync(List<string> messageIds);
    }
}
