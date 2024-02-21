using Application.DTO;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feautures.Client.Commands.DeleteClientCommand
{
    public class DeleteClientCommand : IRequest<Response<int>>
    {
        public int Client_id { get; set; }

    }
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Clients> _repositoryAsync;

        public DeleteClientCommandHandler(IRepositoryAsync<Clients> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var Client_object = await _repositoryAsync.GetByIdAsync(request.Client_id);

            if (Client_object == null)
            {
                string errors = "Client not found";
                return new Response<int>(errors);
            }   
            else
            {
                string message = "Client deleted succesfully.";
                await _repositoryAsync.DeleteAsync(Client_object);
                return new Response<int>(Client_object.Client_id, message);
            }

        }
    }

}
