using System;

namespace ServiceMesh.Framework
{
    public interface IEntity
    {
        public Guid Id { get; set; }
    }

    public class EntityBase : IEntity
    {

        public EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
    }

    public class BussinessEntity : EntityBase
    {

        public BussinessEntity()
        {
            CreatedOn = DateTime.Now;
        }


        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedOn { get; set; }
    }
}
