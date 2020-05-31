using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using ServiceMesh.Accounts.Repositories;
using System.Linq;

namespace ServiceMesh.Accounts.Controllers.Query
{

    [ApiController]
    [Route("accounts")]
    public class AccountQueryController : ControllerBase
    {

        private readonly ServiceUOW _serviceUOW;

        public AccountQueryController(ServiceUOW serviceUOW)
        {
            _serviceUOW = serviceUOW;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetFirstAccount()
        {
            return new OkObjectResult(_serviceUOW.AccountRepository.GetQueryable().FirstOrDefault());
        }

        [HttpGet]
        [Route("{entityId}")]
        public IActionResult GetAccount(Guid guid)
        {
            return new OkObjectResult(_serviceUOW.AccountRepository.GetById(guid));
        }

        [HttpGet]
        [Route("id/{entityId}")]
        public IActionResult GetAccountById(int id)
        {
            return new OkObjectResult(new Accounts.Entities.Account()
            {
                Description = "Christian Di Costanzo",
                FirstName = "Christian",
                LastName = "DC",
                CreatedOn = DateTime.Now
            });
        }

    }
}
