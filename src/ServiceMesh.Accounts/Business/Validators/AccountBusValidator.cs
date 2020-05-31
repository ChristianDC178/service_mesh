using ServiceMesh.Accounts.Entities;
using ServiceMesh.Framework;

namespace ServiceMesh.Accounts.Business.Validators
{
    public class AccountBusValidator
    {
        public Validation ValidateNewAccount( Account account)
        {

            var validation = new Validation();

            if (account.FirstName == string.Empty)
                validation.Items.Add(new ValidationItem("Debe completar el primer nombre"));

            if (account.LastName == string.Empty)
                validation.Items.Add(new ValidationItem("Debe completar el apellido"));

            if (account.Description == string.Empty)
                validation.Items.Add(new ValidationItem("La descripción de la cuenta no puede estar vacia"));

            return validation;

        }


    }
}
