﻿using EvoSystems.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoSystems.Application.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> Get();
        bool Post(UserViewModel userViewModel);
        UserViewModel GetById(string id);
        bool Put(UserViewModel userViewModel);
        bool Delete(string id);
        UsersAuthenticateResponseViewModel Authenticate(UsersAuthenticateResponseViewModel users);
        object Authenticate(UsersAuthenticateRequestViewModel userViewModel);
    }
}
