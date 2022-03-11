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
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public Guid Id { get; private set; }

        public DepartamentoService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        
        public List<UserViewModel> Get()
        {
            List<UserViewModel> _userViewModels = new List<UserViewModel>();

            IEnumerable<Departamento> _Departamento = this.userRepository.GetAll();

            //_userViewModels = mapper.Map<List<UserViewModel>>(_Departamento);

            foreach(var item in _Departamento)
              _userViewModels.Add(mapper.Map<UserViewModel>(item));

               // _userViewModels.Add(new UserViewModel { Id = item.Id, Nome = item.Nome, Sigla = item.Sigla});

            return _userViewModels;
        }

        public bool Post(UserViewModel userViewModel)
        {

            //if(userViewModel.Id != Guid.Empty)
                //throw new Exception("IdDepartamento está vazio");

            //Departamento _Departamento = new Departamento
            //{

               // Id = Guid.NewGuid(),
                //Nome = userViewModel.Nome,
              //  Sigla = userViewModel.Sigla
            //};

            Departamento _Departamento = mapper.Map<Departamento>(userViewModel); 

            this.userRepository.Create(_Departamento); 

            return true;
        }

        public UserViewModel GetById(string id)
        {
            if (!int.TryParse(id, out int depId))
                throw new Exception("Id de departamento inválido");
            Departamento _dep = this.userRepository.Find(x => x.Id == depId && !x.IsDeleted);
            if (_dep == null)
                throw new Exception("Departamento não encontrado");
            return mapper.Map<UserViewModel>(_dep);

        }

        public bool Put(UserViewModel userViewModel)
        {

            Departamento _departamento = this.userRepository.Find(x => x.Id == userViewModel.Id && !x.IsDeleted);
            if (_departamento == null)
                throw new Exception("Departamento não encontrado para editar");
            _departamento = mapper.Map<Departamento>(userViewModel);
            this.userRepository.Update(_departamento);
            return true;
        }

        public bool Delete(string id)
        {
            if (!int.TryParse(id, out int departamentoId))   
                throw new Exception("Id de Departamento não é válido");

            Departamento _departamento = this.userRepository.Find(x => x.Id == departamentoId && !x.IsDeleted);
            if (_departamento == null)
                throw new Exception("Departamento não encontrado");

            return this.userRepository.Delete(_departamento);
        }
    }   

}

    