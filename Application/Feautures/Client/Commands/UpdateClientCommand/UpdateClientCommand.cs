using Application.DTO;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feautures.Client.Commands.UpdateClientCommand
{
    public class UpdateClientCommand : IRequest<Response<int>>
    {
        public int Client_id { get; set; }
        public string? Client_Name { get; set; }
        public string? Client_LastName { get; set; }
        public string? Client_PhoneNumber { get; set; }
        public string? Client_Email { get; set; }
    }
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Clients> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateClientCommandHandler(IRepositoryAsync<Clients> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }



        public async Task<Response<int>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var client_data = await _repositoryAsync.GetByIdAsync(request.Client_id);
            if (client_data == null)
            {
                string message = "Client not found";
                return new Response<int>(message);
            }
            else
            {
                try
                {
                    string message = "Client updated sucessfully.";
                    client_data.Client_Name = request.Client_Name;
                    client_data.Client_LastName = request.Client_LastName;
                    client_data.Client_PhoneNumber = request.Client_PhoneNumber;
                    client_data.Client_Email = request.Client_Email;
                    await _repositoryAsync.UpdateAsync(client_data);
                    return new Response<int>(client_data.Client_id,message);
                }
                catch (Exception ex)
                {
                    string message = "Something went wrong.";
                    return new Response<int>(message);
                }

            }
        }
    }
}
