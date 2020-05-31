using System;
using System.Collections.Generic;
using System.Text;
using ServiceMesh.Accounts.Repositories;
using ServiceMesh.Accounts.Entities;

namespace ServiceMesh.Accounts.Repositories
{
    public class ServiceUOW
    {

        public readonly ServiceContext _serviceContext;
        private readonly GenericRepository<Account> _accountRepository;


        public ServiceUOW(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        public GenericRepository<Account> AccountRepository
        {
            get { return _accountRepository ?? new GenericRepository<Account>(_serviceContext); }
        }

        public void SaveChanges()
        {
            _serviceContext.SaveChanges();
        }


    }
}
