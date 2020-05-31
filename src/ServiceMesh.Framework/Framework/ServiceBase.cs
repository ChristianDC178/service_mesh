using System.Linq;

namespace ServiceMesh.Framework
{

    public class ServiceBase
    {

        public ApiResponse CreateResponse(object data, ApiStatusCode code)
        {
            return new ApiResponse()
            {
                Body = data,
                Code = code
            };
        }


        public ApiResponse CreateResponse(object body, string message, ApiStatusCode code)
        {
            Validation validation = new Validation();
            validation.Add(message);
            return CreateResponse(body, validation, code);
        }


        private ApiResponse CreateResponse(object body, Validation validation, ApiStatusCode code)
        {
            var responseApi = new ApiResponse()
            {
                Body = body,
                Code = code
            };

            if (validation != null)
            {
                responseApi.Validations.AddRange(validation.Items.Select(i => i.Message).ToList());
            }

            return responseApi;
        }


        public ApiResponse Ok(object body, Validation validation = null)
        {
            return CreateResponse(null, validation, ApiStatusCode.Ok);
        }

        public ApiResponse Created(object body = null, string message = "Created")
        {
            return CreateResponse(null, message, ApiStatusCode.Created);
        }

        public ApiResponse Accepted(object body, string message = "Accepted")
        {
            return CreateResponse(null, message, ApiStatusCode.Accepted);
        }

        public ApiResponse Forbidden(string message = "Unauthorized")
        {
            return CreateResponse(null, message, ApiStatusCode.Forbidden);
        }

        public ApiResponse BadRequest(Validation validation = null)
        {
            return CreateResponse(null, validation, ApiStatusCode.BadRequest);
        }

    }

}