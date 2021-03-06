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
    public class UserRepository : Repository<Departamento>, IUserRepository
    {
        public UserRepository(EvoContext context)
            :base(context) { }
        public IEnumerable<Departamento> GetAll()
        {
            return Query(x => !x.IsDeleted);
        }
    }
}
