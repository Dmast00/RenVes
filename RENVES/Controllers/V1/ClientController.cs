using Application.Feautures.Client.Commands.CreateClientCommand;
using Application.Feautures.Client.Queries.GetAllClientsQuery;
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

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllClientsQuery parameters)
        {
            return Ok(await Mediator.Send(new GetAllClientsQuery
            {
                PageNumber = parameters.PageNumber,
                Pagesize = parameters.Pagesize
            }));
        }
    }
}
