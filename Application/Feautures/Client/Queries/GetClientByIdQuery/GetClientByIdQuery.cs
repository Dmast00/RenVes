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

namespace Application.Feautures.Client.Queries.GetClientByIdQuery
{
    public class GetClientByIdQuery : IRequest<Response<ClientsDTO>>
    {
        public int Client_Id { get; set; }


        public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery,Response<ClientsDTO>>
        {
            private readonly IRepositoryAsync<Clients> _repositoryAsync;
            private readonly IMapper _mapper;

            public GetClientByIdQueryHandler(IRepositoryAsync<Clients> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }

            public async Task<Response<ClientsDTO>> Handle(GetClientByIdQuery request,CancellationToken cancellation)
            {
                var Client_object  = await _repositoryAsync.GetByIdAsync(request.Client_Id);

                if(Client_object == null) 
                {
                    string errors = "Client not found";
                    return new Response<ClientsDTO>(errors);
                }
                else
                {
                    var data  = _mapper.Map<ClientsDTO>(Client_object);

                    return new Response<ClientsDTO>(data); 
                }
            }

           
        }

    }
}
