using System;

namespace ServiceMesh.Accounts.Models
{
    public class AccountModel
    {

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
    }
}
