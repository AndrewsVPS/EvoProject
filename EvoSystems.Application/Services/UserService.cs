using AutoMapper;
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
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        
        public List<UserViewModel> Get()
        {
            List<UserViewModel> _userViewModels = new List<UserViewModel>();

            IEnumerable<Users> _users = this.userRepository.GetAll();

            //_userViewModels = mapper.Map<List<UserViewModel>>(_users);

            foreach(var item in _users)
              //_userViewModels.Add(mapper.Map<UserViewModel>(item));

                _userViewModels.Add(new UserViewModel { Id = item.Id, Nome = item.Nome, Sigla = item.Silgla });

            return _userViewModels;
        }

        public bool Post(UserViewModel userViewModel)
        {
             Users _users = new Users
                 {
                    Id = Guid.NewGuid(),
                    Nome = userViewModel.Nome,
                    Silgla = userViewModel.Sigla
                };

            //Users _users = mapper.Map<Users>(userViewModel); 

            this.userRepository.Create(_users); 

            return true;
        }

    }
}
    