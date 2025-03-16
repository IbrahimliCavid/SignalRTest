using Application.Features.Commands;
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
    }
}
