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
    public class DepartamentoServicesTests
    {

        private DepartamentoService DepartamentoService;

        public DepartamentoServicesTests()
        {
            DepartamentoService = new DepartamentoService(new Mock<IUserRepository>().Object, new Mock<IMapper>().Object);
        }

        [Fact]
        public void Post_SendingValidId()
        {
            var exception = Assert.Throws<Exception>(() => DepartamentoService.Post(new UserViewModel { Id = Guid.NewGuid() }));
            Assert.Equal("IdDepartamento está vazio", exception.Message);
        }

        [Fact]
        public void GetById_SendingEmptyGuide()
        {
            var exception = Assert.Throws<Exception>(() => DepartamentoService.GetById(""));
            Assert.Equal("IdDepartamento não é valido", exception.Message);   
        }

        [Fact]
        public void Put_SendingEmptyGuide()
        {
            var exception = Assert.Throws<Exception>(() => DepartamentoService.Put(new UserViewModel()));
            Assert.Equal("ID é invalido", exception.Message);
        }

        [Fact]
        public void Delete_SendingEmptyGuide()
        {
            var exception = Assert.Throws<Exception>(() => DepartamentoService.Delete(""));
            Assert.Equal("IdDepartamento não é valido", exception.Message);
        }

    }
}   
