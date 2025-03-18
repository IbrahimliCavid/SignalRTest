using Application.Dtos;

namespace Application.Features.Queries.Notification.GetAll
{
    public class GetAllNotificationQueryResponse
    {
        public int Count { get; set; }
        public List<GetNotificationDto> Notifications { get; set; } = new();
    }
}