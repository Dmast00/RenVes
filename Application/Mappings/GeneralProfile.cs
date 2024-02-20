﻿using Application.DTO;
using Application.Feautures.Client.Commands.CreateClientCommand;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Clients, ClientsDTO>();


            CreateMap<CreateClientCommand, Clients>();
        }
    }
}
