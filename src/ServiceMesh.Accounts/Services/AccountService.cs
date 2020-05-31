using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceMesh.Accounts.Services
{
    using ServiceMesh.Accounts.Entities;
    using ServiceMesh.Framework;
    using ServiceMesh.Accounts.InputValidators;
    using ServiceMesh.Accounts.Models;
    using ServiceMesh.Accounts.Business;
    using ServiceMesh.Accounts.Adapters;

    public class AccountService : ServiceBase
    {

        private AccountInputValidator _accountInputValidator = new AccountInputValidator();
        private AccountAdapter _accountAdapter = new AccountAdapter();

        private readonly AccountBusiness _accountBusiness;

        public AccountService(AccountBusiness accountBusiness)
        {
            _accountBusiness = accountBusiness;
        }

        public ApiResponse CreateAccount(AccountModel accountModel)
        {

            Validation inputValidation = _accountInputValidator.Validate(accountModel);

            if (inputValidation.IsValid)
            {

                BusinessResult<Account> accountCreateResult =
                    _accountBusiness.CreateAccount(_accountAdapter.AdaptToEntity(accountModel));

                if (accountCreateResult.Validation.IsValid)
                {
                    return CreateResponse(accountCreateResult.Data, ApiStatusCode.Created);
                }
                else
                    return CreateResponse(accountCreateResult.Validation, ApiStatusCode.NotContent);

            }

            return CreateResponse(inputValidation, ApiStatusCode.BadRequest);

        }

        public ApiResponse UpdateAccount(AccountModel model)

        {
            Validation inputValidation = _accountInputValidator.Validate(model);

            if (inputValidation.IsValid)
            {

                BusinessResult<Account> accountCreateResult =
                    _accountBusiness.CreateAccount(_accountAdapter.AdaptToEntity(model));

                return CreateResponse(accountCreateResult, ApiStatusCode.Accepted);

            }

            return CreateResponse(inputValidation, ApiStatusCode.BadRequest);
        }


    }


}
