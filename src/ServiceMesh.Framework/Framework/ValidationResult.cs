namespace ServiceMesh.Framework
{

    public enum ApiStatusCode
    {
        Ok = 200,
        Created = 201, 
        Accepted = 202,
        NotContent = 204,
        //The user is not authorized
        Unauthorized = 401,
        BadRequest = 400,
        //The user is authorized but doesn´t have priveleges
        Forbidden = 403, 
        //Http method not allowed
        NotAllowed = 405
    }
}
