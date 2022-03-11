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
    public class FuncionáriosService : IFuncionáriosRepository
    {
        private readonly IFuncionáriosRepository FuncionáriosRepository;
        private readonly IMapper mapper;
        private object _funcionáriosViewModels;

        public FuncionáriosService(IFuncionáriosService funcionáriosService, IMapper mapper)
        {
            this.mapper = mapper;
        }

        public List<Funcionários> Get()
        {
            List<Funcionários> funcionáriosViewModels = new List<Funcionários>();
            IEnumerable<Funcionários> _funcionários = this.FuncionáriosRepository.GetAll();
            _funcionáriosViewModels = mapper.Map<List<Funcionários>>(_funcionários);

            return (List<Funcionários>)_funcionáriosViewModels;
        }

        public List<Funcionários> GetByDI(int departamentoId)
        {
            List<Funcionários> _funcionáriosViewModel = new List<Funcionários>();
            IEnumerable<Funcionários> _funcionários = FuncionáriosRepository.GetAll();
            foreach (Funcionários funcionários in _funcionários)
            {
                if (funcionários.DepartamentoId == departamentoId)
                    _funcionáriosViewModel.Add(funcionários);
            }
            return _funcionáriosViewModel;
        }

        public bool Post(Funcionários funcionários)
        {
            this.FuncionáriosRepository.Create(funcionários);
            return true;
        }

        public bool Put(Funcionários funcionáriosViewModel)
        {
            Funcionários _funcionários = this.FuncionáriosRepository.Find(x => x.Id == funcionáriosViewModel.Id && !x.IsDeleted);
            if (_funcionários == null)
                throw new Exception("Funcionário não encontrado para editar");
            _funcionários = mapper.Map<Funcionários>(funcionáriosViewModel);
            this.FuncionáriosRepository.Update(_funcionários);
            return true;
        }

        public bool Delete(string id)
        {
            if (!int.TryParse(id, out int funcionáriosId))
                throw new Exception("Id de funcionário não é valido");
            Funcionários _funcionários = this.FuncionáriosRepository.Find(x => x.Id == funcionáriosId && !x.IsDeleted);
            if (_funcionários == null)
                throw new Exception("Funcionário não encontrado");
            return this.FuncionáriosRepository.Delete(_funcionários);
        }
        }

        public Funcionários GetById(string id)
        {
            if (!int.TryParse(id, out int funcionáriosId))
                throw new Exception("ID de Funcionário invalido");
            Funcionários _funcionários = this.FuncionáriosRepository.Find(x => x.Id == funcionáriosId && !x.IsDeleted);
            if (_funcionários == null)
                throw new Exception("Funcionário não encontrado");
            return _funcionários;
        }
    }
