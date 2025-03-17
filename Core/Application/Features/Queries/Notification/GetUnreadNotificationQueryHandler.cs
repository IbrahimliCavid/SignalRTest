using Application.Dtos;
using Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Notification
{
    public class GetUnreadNotificationQueryHandler : IRequestHandler<GetUnreadNotificationQueryRequest, GetUnreadNotificationQueryResponse>
    {
        readonly INotificationService _notificationService;

        public GetUnreadNotificationQueryHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task<GetUnreadNotificationQueryResponse> Handle(GetUnreadNotificationQueryRequest request, CancellationToken cancellationToken)
        {
            var unreadNotifications = new List<GetNotificationDto>();
            if (request.Ids == null)
                 unreadNotifications = await _notificationService.GetUnreadNotifications(new());
            else
            {
                await _notificationService.MarkMessagesAsReadAsync(request.Ids);
                 unreadNotifications = await _notificationService.GetUnreadNotifications(request.Ids);
            }
          
            int count = unreadNotifications.Count;

            return new GetUnreadNotificationQueryResponse()
            {
                Count = unreadNotifications.Count,
                Notifications = unreadNotifications.Select(n => new GetNotificationDto
                {
                    Id =n.Id,
                    Title = n.Title,
                    Message = n.Message
                }).ToList()
            };
        }
    }
}
