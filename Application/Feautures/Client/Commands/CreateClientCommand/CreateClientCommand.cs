using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feautures.Client.Commands.CreateClientCommand
{
    public class CreateClientCommand : IRequest<Response<int>>
    {
        public string? Client_Name { get; set; }
        public string? Client_LastName { get; set; }
        public string? Client_PhoneNumber { get; set; }
        public string? Client_Email { get; set; }
        public DateTime Client_Register_Date { get; set; }
    }


    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Clients> _repositoryAsync;
        private readonly IMapper _mapper;

        public CreateClientCommandHandler(IRepositoryAsync<Clients> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle (CreateClientCommand request ,CancellationToken cancellationToken)
        {
            var map = _mapper.Map<Clients>(request);
            var data = await _repositoryAsync.AddAsync(map);
            string message = "Client Register Succesfully"; 
            return new Response<int>(data.Client_id,message);
        }
    }
}
