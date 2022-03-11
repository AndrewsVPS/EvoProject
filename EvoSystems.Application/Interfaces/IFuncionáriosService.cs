using EvoSystems.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoSystems.Application.Interfaces
{
    public interface IFuncionáriosService 
    {
        List<Funcionários> Get();
        public List<Funcionários> GetByDI(int departamentoId);
        bool Post(Funcionários funcionários);
        bool Put(Funcionários funcionários);
        bool Delete(string id);
    }
}
