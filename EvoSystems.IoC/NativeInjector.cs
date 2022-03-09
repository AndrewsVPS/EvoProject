using EvoSystems.Application.Interfaces;
using EvoSystems.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EvoSystems.IoC
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {

            services.AddScoped<IUserService, UserService>();

        }
    }
}
