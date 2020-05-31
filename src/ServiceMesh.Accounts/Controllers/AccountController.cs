using Microsoft.AspNetCore.Mvc;
using ServiceMesh.Accounts.Models;
using ServiceMesh.Accounts.Repositories;
using System;

namespace ServiceMesh.Accounts.Controllers
{

    using ServiceMesh.Accounts.Services;
    using ServiceMesh.Framework;


    [ApiController]
    [Route("account")]
    public class AccountController : ControllerBase
    {

        private readonly ServiceUOW _serviceUOW ;


        private readonly AccountService _accountService;

        public AccountController(
             ServiceUOW serviceUOW,
             AccountService accountService)
        {
            _serviceUOW = serviceUOW;
            _accountService = accountService;
        }

        [HttpPost]
        public IActionResult CreateAccount(AccountModel model)
        {
            try
            {
                ApiResponse serviceResult = _accountService.CreateAccount(model);

                return this.StatusCode((int)serviceResult.Code, serviceResult);
            }
            catch (Exception  ex)
            {
                throw ex;
            }

        }


        [HttpPut]
        public IActionResult UpdateAccount(AccountModel model)
        {
            try
            {
                ApiResponse serviceResult = _accountService.UpdateAccount(model);

                return this.StatusCode((int)serviceResult.Code, serviceResult);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        [Route("online")]
        public IActionResult IsOnline()
        {
            return this.Ok("Accounts Api OK");
        }

    }
}
