using Application.DTO;
using Application.Interfaces;
using Application.Specification;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feautures.Client.Queries.GetAllClientsQuery
{
    public class GetAllClientsQuery : IRequest<PageResponse<List<ClientsDTO>>>
    {
        public int PageNumber { get; set; }
        public int Pagesize { get; set; }
    }

   public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, PageResponse<List<ClientsDTO>>>
    {
        private readonly IRepositoryAsync<Clients> _repositoryAsync;
        private readonly IMapper _mapper;

        public GetAllClientsQueryHandler(IRepositoryAsync<Clients> repositoryAsync, IMapper mapper)
        {
            _repositoryAsync = repositoryAsync;
            _mapper = mapper;
        }

        public async Task<PageResponse<List<ClientsDTO>>> Handle(GetAllClientsQuery request,CancellationToken cancellation)
        {
            try
            {
                var clientsList = await _repositoryAsync.ListAsync(new PageSpecification<Clients>(request.Pagesize, request.PageNumber));
                var data = _mapper.Map<List<ClientsDTO>>(clientsList);
                
                string message = "Client data loaded successfully.";
                return new PageResponse<List<ClientsDTO>>(data, request.PageNumber, request.Pagesize,message);

            }
            catch (Exception ex)
            {
                
                return new PageResponse<List<ClientsDTO>>(new List<string>{ ex.Message });
                
            }
        }

    }
}
