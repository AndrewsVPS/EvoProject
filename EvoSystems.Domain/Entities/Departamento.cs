using EvoSystems.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EvoSystems.Domain.Entities
{
    public class Departamento : Entity
    {
        public string Nome { get; set; }
        public string Sigla { get; set; }
    }
}
