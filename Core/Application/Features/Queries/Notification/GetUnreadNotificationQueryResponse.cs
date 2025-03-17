using Application.Dtos;

namespace Application.Features.Queries.Notification
{
    public class GetUnreadNotificationQueryResponse
    {
        public int Count { get; set; }
        public List<GetNotificationDto> Notifications { get; set; } = new();
    }
}