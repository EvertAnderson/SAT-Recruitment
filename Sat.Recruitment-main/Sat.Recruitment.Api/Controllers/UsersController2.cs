using System;
using System.IO;

namespace Sat.Recruitment.Api.Controllers
{
    public partial class UsersController
    {
        private StreamReader ReadUsersFromFile()
        {
            //var path = Directory.GetCurrentDirectory() + "/Files/Users.txt";
            var path = Directory.GetCurrentDirectory() + "../Sat.Recruitment.DataAccess/DataBase/Users.txt";

            FileStream fileStream = new FileStream(path, FileMode.Open);

            StreamReader reader = new StreamReader(fileStream);
            return reader;
        }
    }
}
