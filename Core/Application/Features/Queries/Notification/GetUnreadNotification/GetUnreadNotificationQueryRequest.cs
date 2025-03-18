using MediatR;

namespace Application.Features.Queries.Notification.GetUnreadNotification
{
    public class GetUnreadNotificationQueryRequest : IRequest<GetUnreadNotificationQueryResponse>
    {
        public List<string>? Ids { get; set; }
    }
}