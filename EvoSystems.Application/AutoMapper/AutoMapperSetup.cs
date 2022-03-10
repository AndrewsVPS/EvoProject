using AutoMapper;
using EvoSystems.Application.ViewModels;
using EvoSystems.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoSystems.Application.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region ViewModelToDomain

            CreateMap<UserViewModel, Users>();

            #endregion

            #region DomainToViewModel

            CreateMap<Users, UserViewModel>();


            #endregion
        }
    }
}
