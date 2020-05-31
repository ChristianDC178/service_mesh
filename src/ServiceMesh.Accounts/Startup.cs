using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


using Microsoft.AspNetCore.Http;

using System.IO;

using Grpc.AspNetCore;

using ServiceMesh.Accounts.Grpc;

namespace ServiceMesh.Accounts
{

    using ServiceMesh.Accounts.Business;
    using ServiceMesh.Accounts.Repositories;
    using ServiceMesh.Accounts.Services;


    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddGrpc();

            services.AddTransient<ServiceContext>();
            services.AddTransient<ServiceUOW>();

            services.AddTransient<AccountService>();
            services.AddTransient<AccountBusiness>();

            /*
               -- validate the incoming token to make sure it is coming from a trusted issuer
               -- validate that the token is valid to be used with this api (aka audience)
             */
            services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.Authority = "http://localhost:5017";
                options.RequireHttpsMetadata = false;

                options.Audience = "api1";
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapGrpcService<AccountGrpcService>();

                endpoints.MapGet("/_proto/", async ctx =>
                {
                    ctx.Response.ContentType = "text/plain";

                    using var fs = new System.IO. FileStream(System.IO.Path.Combine(env.ContentRootPath, "accounts.proto"), FileMode.Open, FileAccess.Read);
                    using var sr = new System.IO.StreamReader(fs);

                    while (!sr.EndOfStream)
                    {
                        var line = await sr.ReadLineAsync();
                        if (line != "/* >>" || line != "<< */")
                        {
                            await ctx.Response.WriteAsync(line);
                        }
                    }
                });



            });
        }


    }

}
