using MediatR;

namespace Application.Features.Queries.Notification
{
    public class GetUnreadNotificationQueryRequest : IRequest<GetUnreadNotificationQueryResponse>
    {
        public List<string>? Ids { get; set; }
    }
}