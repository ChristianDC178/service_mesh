using System;
namespace ServiceMesh.Products.Entities
{

    public class EntityBase
    {

        public Guid EntityId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

    }

    public class Product : EntityBase
    {

    }
}
