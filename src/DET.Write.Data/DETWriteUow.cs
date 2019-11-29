using DET.Write.Domain;
using SharedKernel.Data;
using SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DET.Write.Data
{
    public class DETWriteUow : IUow
    {
        private DETWriteContext _detContext;

        public DETWriteUow(DETWriteContext detContext)
        {
            _detContext = detContext;
        }

        public GenericRepository<RoleCommand> RoleRepo { get { return new GenericRepository<RoleCommand>(_detContext); } }
        public GenericRepository<UserCommand> UserRepo { get { return new GenericRepository<UserCommand>(_detContext); } }

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
