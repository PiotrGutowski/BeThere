using AutoMapper;

using BeThere.Infrastructure.Users.Commands;
using BeThere.Infrastructure.Users.Dto;
using BeThere.Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeThere.Infrastructure.Mappings.Profiles
{
    public class UserToUserDtoProfile : Profile
    {

        public UserToUserDtoProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
