using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ServiceMesh.Framework;
using ServiceMesh.Accounts.Entities;
using ServiceMesh.Accounts.Business.Validators;
using ServiceMesh.Accounts.Repositories;

namespace ServiceMesh.Accounts.Business
{
    public class AccountBusiness
    {

        private readonly AccountBusValidator _accountBusValidator = new AccountBusValidator();
        private readonly ServiceUOW _serviceUOW;


        public AccountBusiness(
            ServiceUOW serviceUOW)
        {
            _serviceUOW = serviceUOW;
        }


        public BusinessResult<Account> CreateAccount(Account account)
        {
            try
            {


                Validation validation = _accountBusValidator.ValidateNewAccount(account);
                var bussinesResult = new BusinessResult<Account>(validation);

                if (validation.IsValid)
                {
                    bussinesResult.Data = account;

                    _serviceUOW.AccountRepository.Create(account);
                    _serviceUOW.SaveChanges();
                }

                return bussinesResult;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            return null;
        }


        public BusinessResult<Account> UpdateAccount(Account account)
        {

            Validation validation = _accountBusValidator.ValidateNewAccount(account);
            var bussinesResult = new BusinessResult<Account>(validation);

            if (validation.IsValid)
            {

                Account accountBus = _serviceUOW.AccountRepository.GetById(account.Id);

                accountBus.FirstName = account.FirstName;
                accountBus.LastName = account.LastName;

                _serviceUOW.AccountRepository.Update(account);
                _serviceUOW.SaveChanges();

                bussinesResult.Data = account;
            }

            return bussinesResult;

        }

    }
}
