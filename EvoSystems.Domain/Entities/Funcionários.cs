using EvoSystems.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoSystems.Domain.Entities
{
    public class Funcionários : Entity
    {
        public string Nome { get; set; }
        public string RG { get; set; }
        public string Foto { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        public new bool IsDeleted { get; set; }
    }
}
