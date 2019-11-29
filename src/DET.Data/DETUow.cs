using DET.Domain;
using SharedKernel.Data;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DET.Data
{
    public class DETUow : IUow
    {
        private DETContext _detContext;

        public DETUow(DETContext detContext)
        {
            _detContext = detContext;
        }

        public GenericRepository<Role> RoleRepo { get { return new GenericRepository<Role>(_detContext); } }
        public GenericRepository<User> UserRepo { get { return new GenericRepository<User>(_detContext); } }

        public void Dispose()
        {
            _detContext.Dispose();
        }

        public void Save()
        {
            _detContext.SaveChanges();
        }
    }
}
