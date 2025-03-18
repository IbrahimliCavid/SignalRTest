using Application.Dtos;
using Application.Features.Queries.Notification.GetUnreadNotification;
using Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries.Notification.GetAll
{
    public class GetAllNotificationQueryHandler : IRequestHandler<GetAllNotificationQueryRequest, GetAllNotificationQueryResponse>
    {
        readonly INotificationService _notificationService;

        public GetAllNotificationQueryHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task<GetAllNotificationQueryResponse> Handle(GetAllNotificationQueryRequest request, CancellationToken cancellationToken)
        {
           var notifications =  await _notificationService.GetAll();

            return new GetAllNotificationQueryResponse()
            {
                Count = notifications.Count,
                Notifications = notifications.Select(n => new GetNotificationDto
                {
                    Id = n.Id,
                    Title = n.Title,
                    Message = n.Message
                }).ToList()
            };

        }
    }
}
