using AutoMapper;
using EvoSystems.Application.Interfaces;
using EvoSystems.Domain.Entities;
using EvoSystems.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoSystems.Application.Services
{
    public class FuncionáriosService : IFuncionáriosService
    {
        private readonly IFuncionáriosRepository funcionáriosRepository;
        private readonly IMapper mapper;
        private object _funcionáriosViewModels;

        public FuncionáriosService(IFuncionáriosService funcionáriosService, IMapper mapper)
        {
            this.funcionáriosRepository = funcionáriosRepository;
            this.mapper = mapper;
        }

        public List<Funcionários> Get()
        {
            List<Funcionários> funcionáriosViewModels = new List<Funcionários>();
            IEnumerable<Funcionários> _funcionários = this.funcionáriosRepository.GetAll();
            _funcionáriosViewModels = mapper.Map<List<Funcionários>>(_funcionários);

            return (List<Funcionários>)_funcionáriosViewModels;
        }

        public static List<Funcionários> GetByDI(int departamentoId)
        {
            List<Funcionários> _funcionáriosViewModel = new List<Funcionários>();
            IEnumerable<Funcionários> _funcionários = this.funcionáriosRepository.GetAll();
            foreach (Funcionários funcionários in _funcionários)
            {
                if (funcionários.DepartamentoId == departamentoId)
                    _funcionáriosViewModel.Add(funcionários);
            }
            return _funcionáriosViewModel;
        }

        public bool Post(Funcionários funcionários)
        {
            this.funcionáriosRepository.Create(funcionários);
            return true;
        }

        public bool Put(Funcionários funcionáriosViewModel)
        {
            Funcionários _funcionários = this.funcionáriosRepository.Find(x => x.Id == funcionáriosViewModel.Id && !x.IsDeleted);
            if (_funcionários == null)
                throw new Exception("Funcionário não encontrado para editar");
            _funcionários = mapper.Map<Funcionários>(funcionáriosViewModel);
            this.funcionáriosRepository.Update(_funcionários);
            return true;
        }

        public bool Delete(string id)
        {
            if (!int.TryParse(id, out int funcionáriosId))
                throw new Exception("Id de funcionário não é valido");
            Funcionários _funcionários = this.funcionáriosRepository.Find(x => x.Id == funcionáriosId && !x.IsDeleted);
            if (_funcionários == null)
                throw new Exception("Funcionário não encontrado");
            return this.funcionáriosRepository.Delete(_funcionários);
        }

        public List<Funcionários> GetById(int departamentoId)
        {
            throw new NotImplementedException();
        }

        public Funcionários GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
