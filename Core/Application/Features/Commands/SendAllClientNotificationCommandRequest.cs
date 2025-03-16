using MediatR;

namespace Application.Features.Commands
{
    public class SendAllClientNotificationCommandRequest : IRequest<SendAllClientNotificationCommandResponse>
    {
        public string Title { get; set; }
        public string Message {  get; set; }
    }
}