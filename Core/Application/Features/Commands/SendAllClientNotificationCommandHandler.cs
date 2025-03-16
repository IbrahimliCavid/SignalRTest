using Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public class SendAllClientNotificationCommandHandler : IRequestHandler<SendAllClientNotificationCommandRequest, SendAllClientNotificationCommandResponse>
    {
        readonly INotificationService _notificationService;

        public SendAllClientNotificationCommandHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task<SendAllClientNotificationCommandResponse> Handle(SendAllClientNotificationCommandRequest request, CancellationToken cancellationToken)
        {
         var result = await  _notificationService.SendNotificationAllClient(new()
            {
                Title = request.Title,
                Message = request.Message
            });

            return new()
            {
                Success = result
            };

        }
    }
}
