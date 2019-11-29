using AutoMapper;
using DET.Web.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DET.Read.Data.Services
{
    public class DETReadData
    {
        private readonly IMapper _mapper;
        private DETReadUow _detUow;

        public DETReadData(IMapper mapper, DETReadUow detUow)
        {
            _mapper = mapper;
            _detUow = detUow;
        }

        #region Role

        public IList<RoleVM> GetRole()
        {
            var rolesData = _detUow.RoleGenRepo.GetAll();
            var rolesVM = _mapper.Map<IList<RoleVM>>(rolesData);
            return rolesVM;
        }

        public RoleVM GetRoleById(int id)
        {
            var roleData = _detUow.RoleGenRepo.GetById(id);
            var roleVM = _mapper.Map<RoleVM>(roleData);
            return roleVM;
        }

        #endregion Role

        #region User

        public IList<UserVM> GetUser()
        {
            var usersData = _detUow.UserGenRepo.GetAll();
            var usersVM = _mapper.Map<IList<UserVM>>(usersData);
            return usersVM;
        }

        public IList<UserVM> GetUserWithGraph()
        {
            var usersData = _detUow.UserGenRepo.GetAllInclude
                (
                    source => source
                                .Include(x => x.Role)
                );
            var usersVM = _mapper.Map<IList<UserVM>>(usersData);
            return usersVM;
        }

        public UserVM GetUserById(int id)
        {
            var userData = _detUow.UserGenRepo.GetById(id);
            var userVM = _mapper.Map<UserVM>(userData);
            return userVM;
        }

        #endregion User

        #region UserRoles

        public IList<UserRoleModelVM> GetAllUserRoleModel()
        {
            var userRolesData = _detUow.UserRepo.GetAllUserRoles();
            var userRolesVM = _mapper.Map<IList<UserRoleModelVM>>(userRolesData);
            return userRolesVM;
        }

        #endregion UserRoles
    }
}
