using Application.Feautures.Client.Commands.CreateClientCommand;
using Microsoft.AspNetCore.Mvc;

namespace RENVES.Controllers.V1
{
    [ApiVersion("1.0")]
    public class ClientController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateClientCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
