using AutoMapper;
using DET.Web.ViewModels;
using DET.Write.Data.CommandHandlers;
using DET.Write.Domain;
using SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DET.Write.Data.Services
{
    public class DETWriteData
    {
        private readonly IMapper _mapper;
        private readonly Messages _messages;

        public DETWriteData(IMapper mapper, Messages messages)
        {
            _mapper = mapper;
            _messages = messages;
        }

        #region Role

        public void AddRole(RoleVM value)
        {
            var roleData = _mapper.Map<AddRoleCommand>(value);
            _messages.Dispatch(roleData);
            //var handler = new AddRoleCommandHandler(_detUow);
            //handler.Handle(roleData);
        }

        public void UpdateRole(RoleVM value)
        {
            var roleData = _mapper.Map<UpdateRoleCommand>(value);
            _messages.Dispatch(roleData);
        }

        public void DeleteRole(RoleVM value)
        {
            var roleData = _mapper.Map<DeleteRoleCommand>(value);
            _messages.Dispatch(roleData);
        }

        #endregion Role

        #region User

        public void AddUser(UserVM value)
        {
            var userData = _mapper.Map<AddUserCommand>(value);
            _messages.Dispatch(userData);
        }

        public void UpdateUser(UserVM value)
        {
            var userData = _mapper.Map<UpdateUserCommand>(value);
            _messages.Dispatch(userData);
        }

        public void DeleteUser(UserVM value)
        {
            var userData = _mapper.Map<DeleteUserCommand>(value);
            _messages.Dispatch(userData);
        }

        #endregion User
    }
}
