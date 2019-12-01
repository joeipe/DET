using System;
using DET.Read.Data.Services;
using DET.Web.ViewModels;
using DET.Write.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Interfaces;

namespace DET.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DetController : ApiController
    {
        private DETReadData _detReadData;
        private DETWriteData _detWriteData;

        public DetController(DETReadData detReadData, DETWriteData detWriteData)
        {
            _detReadData = detReadData;
            _detWriteData = detWriteData;
        }

        #region Role

        [HttpGet]
        public ActionResult GetRole()
        {
            return Response(_detReadData.GetRole());
        }

        [HttpGet("{id}")]
        public ActionResult GetRoleById(int id)
        {
            var roleVM = _detReadData.GetRoleById(id);

            if (roleVM == null)
            {
                return ResponseNotFound();
            }

            return Response(roleVM);
        }

        [HttpPost]
        public ActionResult AddRole([FromBody]RoleVM value)
        {
            _detWriteData.AddRole(value);

            return Response("", value);
        }

        [HttpPost]
        public ActionResult UpdateRole([FromBody]RoleVM value)
        {
            _detWriteData.UpdateRole(value);

            return Response();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRole(int id)
        {
            var roleVM = _detReadData.GetRoleById(id);
            if (roleVM == null)
            {
                return ResponseNotFound();
            }

            _detWriteData.DeleteRole(roleVM);

            return Response();
        }

        #endregion Role

        #region User

        [HttpGet]
        public ActionResult GetUser()
        {
            return Response(_detReadData.GetUser());
        }

        [HttpGet]
        public ActionResult GetUserWithGraph()
        {
            return Response(_detReadData.GetUserWithGraph());
        }

        [HttpGet("{id}")]
        public ActionResult GetUserById(int id)
        {
            var userVM = _detReadData.GetUserById(id);

            if (userVM == null)
            {
                return ResponseNotFound();
            }

            return Response(userVM);
        }

        [HttpPost]
        public ActionResult AddUser([FromBody]UserVM value)
        {
            _detWriteData.AddUser(value);

            return Response("", value);
        }

        [HttpPost]
        public ActionResult UpdateUser([FromBody]UserVM value)
        {
            _detWriteData.UpdateUser(value);

            return Response();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var userVM = _detReadData.GetUserById(id);
            if (userVM == null)
            {
                return ResponseNotFound();
            }

            _detWriteData.DeleteUser(userVM);

            return Response();
        }

        #endregion User

        #region UserRoles

        [HttpGet]
        public ActionResult GetAllUserRoleModel()
        {
            return Response(_detReadData.GetAllUserRoleModel());
        }

        #endregion UserRoles
    }
}