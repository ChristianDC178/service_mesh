using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ServiceMesh.Accounts.Services;

namespace ServiceMesh.Accounts.Grpc
{
    public class AccountGrpcService : AccountsService.AccountsServiceBase
    {

        private readonly ILogger<AccountGrpcService> _logger;
        private readonly AccountService _accountService;

        public AccountGrpcService(ILogger<AccountGrpcService> logger, 
            AccountService accountService
            )
        {
            _logger = logger;
            _accountService = accountService;
        }


        public override Task<Response> CreateAccount(AccountModel request, ServerCallContext context)
        {
            //if (context.Method == "post")
            //{
                
            //}

            return Task.FromResult<Response>(new Response() { AccountId = "1" });
            
        }


    }
}
