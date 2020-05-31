using System.Collections.Generic;

namespace ServiceMesh.Framework
{

    public class ApiResponse
    {

        public object Body { get; set; }

        public ApiStatusCode Code { get; set; }

        public string ErrorMessage { get; set; }

        public bool IsValid
        {
            get
            {
                return Code !=
                    (ApiStatusCode.BadRequest |
                    ApiStatusCode.Unauthorized |
                    ApiStatusCode.Forbidden);
            }
        }

        public List<string> Validations { get; set; } = new List<string>();

    }


}
