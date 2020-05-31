namespace ServiceMesh.Accounts.Entities
{

    using ServiceMesh.Framework;

    public class Account : BussinessEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}
