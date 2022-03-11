using EvoSystems.Data.Context;
using EvoSystems.Domain.Entities;
using EvoSystems.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Data.Repositories;

namespace EvoSystems.Data.Repositories
{
    public class FuncionáriosRepository : Repository<Funcionários>, IFuncionáriosRepository
    {
        public FuncionáriosRepository(EvoContext context) 
            : base(context) { }

        public IEnumerable<Funcionários> GetAll()
        {
            return Query(x => !x.IsDeleted);
        }
    }
}
