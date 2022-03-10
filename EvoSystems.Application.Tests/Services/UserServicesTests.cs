using AutoMapper;
using EvoSystems.Application.Services;
using EvoSystems.Application.ViewModels;
using EvoSystems.Domain.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EvoSystems.Application.Tests.Services
{
    public class UserServicesTests
    {

        private UserService userService;

        public UserServicesTests()
        {
            userService = new UserService(new Mock<IUserRepository>().Object, new Mock<IMapper>().Object);
        }

        [Fact]
        public void Post_SendingValidId()
        {
            var exception = Assert.Throws<Exception>(() => userService.Post(new UserViewModel { Id = Guid.NewGuid() }));
            Assert.Equal("IdDepartamento está vazio", exception.Message);
        }

        [Fact]
        public void GetById_SendingEmptyGuide()
        {
            var exception = Assert.Throws<Exception>(() => userService.GetById(""));
            Assert.Equal("IdDepartamento não é valido", exception.Message);   
        }

        [Fact]
        public void Put_SendingEmptyGuide()
        {
            var exception = Assert.Throws<Exception>(() => userService.Put(new UserViewModel()));
            Assert.Equal("ID é invalido", exception.Message);
        }

        [Fact]
        public void Delete_SendingEmptyGuide()
        {
            var exception = Assert.Throws<Exception>(() => userService.Delete(""));
            Assert.Equal("IdDepartamento não é valido", exception.Message);
        }

    }
}   
