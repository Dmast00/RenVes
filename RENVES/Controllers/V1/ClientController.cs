using Application.Feautures.Client.Commands.CreateClientCommand;
using Application.Feautures.Client.Commands.DeleteClientCommand;
using Application.Feautures.Client.Commands.UpdateClientCommand;
using Application.Feautures.Client.Queries.GetAllClientsQuery;
using Application.Feautures.Client.Queries.GetClientByIdQuery;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetClientByIdQuery
            {
                Client_Id = id,
            }));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateClientCommand command)
        {

            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteClientCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
