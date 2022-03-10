using EvoSystems.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoSystems.Application.ViewModels
{
    public class UsersAuthenticateResponseViewModel
    {
        public UsersAuthenticateResponseViewModel(UserViewModel users, string token)
        {
            this.Users = users;
            this.Token = token;
        }

        public UserViewModel Users { get; set; }
        public string Token { get; set; }
        public object Email { get; internal set; }
    }
}
