using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ServiceMesh.Accounts.Entities;
using ServiceMesh.Accounts.Models;

namespace ServiceMesh.Accounts.Contracts
{
    public interface IAccountContract
    {

        AccountModel CreateAccount(AccountModel accountModel);


    }
}
