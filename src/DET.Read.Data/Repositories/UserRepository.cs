using DET.Read.Domain;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DET.Read.Data.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        private DETReadContext _detContext;

        public UserRepository(DETReadContext detContext)
            :base(detContext)
        {
            _detContext = detContext;
        }

        public IEnumerable<UserRoleModel> GetAllUserRoles()
        {
            var query = @"select U.FirstName + ' ' + U.LastName UserName, R.Name Role
                          from Users U
                           inner join Roles R on R.Id=U.RoleId";

            return Task.Run(() => _detContext.UserRoleModels.FromSql(query).ToListAsync()).Result;
        }
    }
}
