using AutoMapper;
using DET.Read.Domain;
using DET.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DET.Web.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Role, RoleVM>();

            CreateMap<User, UserVM>();

            CreateMap<UserRoleModel, UserRoleModelVM>();
        }
    }
}
