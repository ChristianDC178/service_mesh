using ServiceMesh.Accounts.Entities;
using ServiceMesh.Accounts.Models;

namespace ServiceMesh.Accounts.Adapters
{
    public class AccountAdapter
    {

        public Account AdaptToEntity(AccountModel accountModel)
        {
            return new Account()
            {
                FirstName = accountModel.FirstName,
                LastName = accountModel.LastName,
                Description = accountModel.Description
            };
        }

    }
}
