using DET.Read.Data.Repositories;
using DET.Read.Domain;
using SharedKernel.Data;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DET.Read.Data
{
    public class DETReadUow : IUow
    {
        private DETReadContext _detContext;

        public DETReadUow(DETReadContext detContext)
        {
            _detContext = detContext;
        }

        public GenericRepository<Role> RoleGenRepo { get { return new GenericRepository<Role>(_detContext); } }
        public GenericRepository<User> UserGenRepo { get { return new GenericRepository<User>(_detContext); } }

        public UserRepository UserRepo { get { return new UserRepository(_detContext); } }

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
