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
    }
}