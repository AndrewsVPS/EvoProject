using EvoSystems.Application.Interfaces;
using EvoSystems.Application.ViewModels;
using EvoSystems.Domain.Entities;
using EvoSystems.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoSystems.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        
        public List<UserViewModel> Get()
        {
            List<UserViewModel> _userViewModels = new List<UserViewModel>();

            IEnumerable<Users> _users = this.userRepository.GetAll();

            foreach(var item in _users)
                _userViewModels.Add(new UserViewModel { Id = item.Id, Nome = item.Nome, Sigla = item.Silgla });

            return _userViewModels;
        }
    }
}
    