using EvoSystems.Application.Interfaces;
using EvoSystems.Application.Services;
using EvoSystems.Data.Repositories;
using EvoSystems.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EvoSystems.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Services

            services.AddScoped<IUserService, UserService>();

            #endregion

            #region Repositories

            services.AddScoped<IUserRepository, UserRepository>();

            #endregion

        }
    }
}
