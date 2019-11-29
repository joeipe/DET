using DET.Domain;
using DET.Web.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DET.Data.Services
{
    public class DETData
    {
        private DETUow _detUow;

        public DETData(DETUow detUow)
        {
            _detUow = detUow;
        }

        #region Role
        public IList<RoleVM> GetRole()
        {
            var rolesData = _detUow.RoleRepo.GetAll();
            var rolesVM = ObjectMapper.Mapper.Map<IList<RoleVM>>(rolesData);
            return rolesVM;
        }

        public RoleVM GetRoleById(int id)
        {
            var roleData = _detUow.RoleRepo.GetById(id);
            var roleVM = ObjectMapper.Mapper.Map<RoleVM>(roleData);
            return roleVM;
        }

        public void AddRole(RoleVM value)
        {
            var roleData = ObjectMapper.Mapper.Map<Role>(value);
            _detUow.RoleRepo.Add<Role>(roleData);
            _detUow.Save();
        }

        public void UpdateRole(RoleVM value)
        {
            var roleData = ObjectMapper.Mapper.Map<Role>(value);
            _detUow.RoleRepo.Edit<Role>(roleData);
            _detUow.Save();
        }

        public void DeleteRole(RoleVM value)
        {
            var roleData = ObjectMapper.Mapper.Map<Role>(value);
            _detUow.RoleRepo.Delete(roleData);
            _detUow.Save();
        }
        #endregion Role

        #region User
        public IList<UserVM> GetUser()
        {
            var usersData = _detUow.UserRepo.GetAll();
            var usersVM = ObjectMapper.Mapper.Map<IList<UserVM>>(usersData);
            return usersVM;
        }

        public IList<UserVM> GetUserWithGraph()
        {
            var usersData = _detUow.UserRepo.GetAllInclude
                (
                    source => source
                                .Include(x => x.Role)
                );
            var usersVM = ObjectMapper.Mapper.Map<IList<UserVM>>(usersData);
            return usersVM;
        }

        public UserVM GetUserById(int id)
        {
            var userData = _detUow.UserRepo.GetById(id);
            var userVM = ObjectMapper.Mapper.Map<UserVM>(userData);
            return userVM;
        }

        public void AddUser(UserVM value)
        {
            var userData = ObjectMapper.Mapper.Map<User>(value);
            _detUow.UserRepo.Add<User>(userData);
            _detUow.Save();
        }

        public void UpdateUser(UserVM value)
        {
            var userData = ObjectMapper.Mapper.Map<User>(value);
            _detUow.UserRepo.Edit<User>(userData);
            _detUow.Save();
        }

        public void DeleteUser(UserVM value)
        {
            var userData = ObjectMapper.Mapper.Map<User>(value);
            _detUow.UserRepo.Delete(userData);
            _detUow.Save();
        }
        #endregion User
    }
}
