using EvoSystems.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoSystems.Domain.Interfaces
{
    public interface IFuncionáriosRepository : IRepository<Funcionários>
    {
        IEnumerable<Funcionários> GetAll();
    }
}
