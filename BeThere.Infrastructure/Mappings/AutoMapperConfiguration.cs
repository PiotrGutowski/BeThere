using AutoMapper;
using BeThere.Infrastructure.Mappings.Profiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeThere.Infrastructure.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<UserToUserDtoProfile>();
            });
        }
    }
}
