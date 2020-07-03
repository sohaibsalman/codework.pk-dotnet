using AutoMapper;
using CodeWork.Dtos;
using CodeWork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeWork.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<User, UserLoginDto>();
            Mapper.CreateMap<UserLoginDto, User>();

            Mapper.CreateMap<User, SessionData>();
        }
    }
}