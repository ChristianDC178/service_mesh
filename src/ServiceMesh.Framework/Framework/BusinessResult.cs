namespace ServiceMesh.Framework
{

    public class BusinessResult<T> where T : IEntity
    {

        public BusinessResult() { }

        public Validation Validation { get; set; } = new Validation();

        public T Data { get; set; }

        public BusinessResult(Validation validation)
        {
            Validation = validation;
        }
      
    }
}
