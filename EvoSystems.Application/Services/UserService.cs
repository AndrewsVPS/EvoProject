using AutoMapper;
using Evo.Auth.Services;
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

                _userViewModels.Add(new UserViewModel { Id = item.Id, Nome = item.Nome, Sigla = item.Email });

            return _userViewModels;
        }

        public bool Post(UserViewModel userViewModel)
        {
             Users _users = new Users
                 {
                    Id = Guid.NewGuid(),
                    Nome = userViewModel.Nome,
                    Email = userViewModel.Sigla
                };

            //Users _users = mapper.Map<Users>(userViewModel); 

            this.userRepository.Create(_users); 

            return true;
        }

        public UserViewModel GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid userId))
                throw new Exception("Departamento não é válido");

            Users _users = this.userRepository.Find(x => x.Id == userId && !x.IsDeleted);
            if (_users == null)
                throw new Exception("Departamento não encontrado");

            return mapper.Map<UserViewModel>(_users);
        }

        public bool Put(UserViewModel userViewModel)
        {
            Users _users = this.userRepository.Find(x => x.Id == userViewModel.Id && !x.IsDeleted);
            if (_users == null)
                throw new Exception("Departamento não encontrado");

            _users = mapper.Map<Users>(userViewModel);

            this.userRepository.Update(_users);

            return true;
        }

        public bool Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid userId))
                throw new Exception("Departamento não é válido");

            Users _users = this.userRepository.Find(x => x.Id == userId && !x.IsDeleted);
            if (_users == null)
                throw new Exception("Departamento não encontrado");

            return this.userRepository.Delete(_users);
        }
    }   

}

    