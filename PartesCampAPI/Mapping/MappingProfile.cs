using AutoMapper;
using PartesCampAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartesCampAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //User
            CreateMap<User, UserGetDTO>();
            CreateMap<UserPostDTO, User>();

            //Tarea
            CreateMap<Tarea, TareaGetDTO>();
            CreateMap<TareaPostDTO, Tarea>();

            //Clients
            CreateMap<Client, ClientGetDTO>();
            CreateMap<ClientPostDTO, Client>();

            //Lands
            CreateMap<Land, LandGetDTO>();
            CreateMap<LandPostDTO, Land>();
        }
    }
}
