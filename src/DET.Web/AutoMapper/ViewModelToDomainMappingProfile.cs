using AutoMapper;
using DET.Write.Domain;
using DET.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DET.Web.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<RoleVM, AddRoleCommand>()
                .ConstructUsing(c => new AddRoleCommand(c.Name));

            CreateMap<RoleVM, UpdateRoleCommand>()
                .ConstructUsing(c => new UpdateRoleCommand(c.Id, c.Name));

            CreateMap<RoleVM, DeleteRoleCommand>()
                .ConstructUsing(c => new DeleteRoleCommand(c.Id, c.Name));

            CreateMap<RoleVM, DeleteRoleCommand>()
                .ConstructUsing(c => new DeleteRoleCommand(c.Id, c.Name));

            CreateMap<UserVM, AddUserCommand>()
                .ConstructUsing(c => new AddUserCommand(c.FirstName, c.LastName, c.RoleId));

            CreateMap<UserVM, UpdateUserCommand>()
                .ConstructUsing(c => new UpdateUserCommand(c.Id, c.FirstName, c.LastName, c.RoleId));

            CreateMap<UserVM, DeleteUserCommand>()
                .ConstructUsing(c => new DeleteUserCommand(c.Id, c.FirstName, c.LastName, c.RoleId));
        }
    }
}
