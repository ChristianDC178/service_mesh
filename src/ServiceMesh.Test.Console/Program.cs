using System;
using System.Net.Http;
using System.Threading.Tasks;


using Grpc.Core;
using Grpc.Net.Client;
using ServiceMesh.Accounts.Grpc;

using IdentityModel.Client;
using Newtonsoft.Json.Linq;

namespace ServiceMesh.Test
{
    class Program
    {
        static void Main(string[] args)
        {


            TestIdentityServer();


            


        }


        static void TestGrpc()
        {
            try
            {

                GrpcChannel channel = GrpcChannel.ForAddress("https://localhost:5001");

                var client = new AccountsService.AccountsServiceClient(channel);

                var reply = client.CreateAccountAsync(
                    new AccountModel
                    {
                        FirstName = "Christian",
                        LastName = "Di Costanzo"
                    }).GetAwaiter().GetResult();

                Console.WriteLine("New Account: " + reply.AccountId);

                channel.ShutdownAsync().Wait();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }

        static  void TestIdentityServer()
        {
            // discover endpoints from metadata
            var client = new HttpClient();
            var disco = client.GetDiscoveryDocumentAsync("http://localhost:5017").Result;
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }

            // request token
            var tokenResponse =  client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,

                ClientId = "client",
                ClientSecret = "secret",
                Scope = "api11"
            }).Result;

            

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            //calling the api
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var response = apiClient.GetAsync("http://localhost:5017/identity").Result;
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(JArray.Parse(content));
            }

            Console.WriteLine(tokenResponse.Json);


        }
    }


}
