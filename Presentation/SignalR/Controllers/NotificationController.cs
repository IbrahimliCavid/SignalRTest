using Application.Features.Commands;
using Application.Features.Queries.Notification.GetAll;
using Application.Features.Queries.Notification.GetUnreadNotification;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        readonly IMediator _mediator;

        public NotificationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> SendAllClientNotification([FromBody]SendAllClientNotificationCommandRequest request)
        {
            SendAllClientNotificationCommandResponse response =await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUnreadMessages([FromQuery]GetUnreadNotificationQueryRequest? request)
        {
            if (request == null || request.Ids == null || !request.Ids.Any())
            {
                request = new GetUnreadNotificationQueryRequest { Ids = new List<string>() };
            }

            GetUnreadNotificationQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllNotification()
        {
            GetAllNotificationQueryResponse response = await _mediator.Send(new GetAllNotificationQueryRequest());
            return Ok(response);
        }
    }
}
