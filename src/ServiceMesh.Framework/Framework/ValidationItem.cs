namespace ServiceMesh.Framework
{
    public class ValidationItem
    {
        public ValidationItem(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
}
