using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ServiceMesh.Accounts.Models;
using ServiceMesh.Framework;

namespace ServiceMesh.Accounts.InputValidators
{
    public class AccountInputValidator
    {

        public Validation Validate(AccountModel accountModel)
        {

            var validation = new Validation();

            if (string.IsNullOrEmpty(accountModel.Description))
                validation.Add("El campo decripción no puede estar vacio");

            return validation;
        }

    }
}
