using Microsoft.AspNetCore.Mvc;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.BL.Rules;
using Sat.Recruitment.Models;
using Sat.Recruitment.DataAccess.DataBase;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class UsersController : ControllerBase
    {
        private readonly List<User> _users = new List<User>();
        public UsersController()
        {
        }

        public List<User> Users => _users;

        [HttpPost]
        [Route("/create-user")]
        public async Task<Result> CreateUser(string name, string email, string address, string phone, string userType, string money)
        {
            var objBL = new ValidateUser(name, email, address, phone, userType, money);

            var errors = objBL.GetErrors();

            if (errors != null && errors != "") return GenerateResult(false, errors);

            var newUser = objBL.GetUser();

            _users.AddRange(new TxtReadWrite(ReadUsers.ReadUsersFromFile()).GetUserList());

            try
            {
                var isDuplicated = objBL.isDuplicated(_users);

                if (!isDuplicated)
                {
                    return GenerateResult(true, "User Created", "User Created");
                }
                else
                {
                    return GenerateResult(false, "The user is duplicated", "The user is duplicated");
                }
            }
            catch
            {
                return GenerateResult(false, "The user is duplicated", "The user is duplicated");
            }

            return GenerateResult(true, "User Created");
        }

        private Result GenerateResult(bool status, string message, string? debugMessage = null)
        {
            if (debugMessage != null) Debug.WriteLine(debugMessage);

            return new Result() { IsSuccess = status, Errors = message };
        }
    }
}
