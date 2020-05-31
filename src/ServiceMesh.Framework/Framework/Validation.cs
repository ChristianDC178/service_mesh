using System.Collections.Generic;

namespace ServiceMesh.Framework
{
    public class Validation
    {
        public List<ValidationItem> Items { get; set; } = new List<ValidationItem>();
        public bool IsValid { get { return Items.Count == 0; } }

        public void Add(string messagee)
        {
            Items.Add(new ValidationItem(messagee));
        }

    }
}
