using AutoMapper;
using BeThere.Infrastructure.Users.Commands;
using BeThere.Infrastructure.Users.Dto;
using BeThere.Model.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeThere.Infrastructure.Mappings.Extensions
{
    public static class ObjectMapperExtensions
    {

        public static UserDto MapToUserDto(this User source)
        {
            return Mapper.Map<UserDto>(source);
        }
    }
}
