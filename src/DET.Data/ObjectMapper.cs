using AutoMapper;
using DET.Domain;
using DET.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DET.Data
{
    public static class ObjectMapper
    {
        private static IMapper _mapper;

        public static IMapper Mapper
        {
            get
            {
                return _mapper;
            }
        }

        static ObjectMapper()
        {
            CreateMap();
        }

        private static void CreateMap()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Role, RoleVM>();
                cfg.CreateMap<RoleVM, Role>();

                cfg.CreateMap<User, UserVM>();
                cfg.CreateMap<UserVM, User>();
            });

            _mapper = config.CreateMapper();
        }
    }
}
