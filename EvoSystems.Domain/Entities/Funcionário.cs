using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoSystems.Domain.Entities
{
    public class Funcionário
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Foto { get; set; }
        public string RG { get; set; }
        public Guid IdDepartamento { get; set; }
    }
}
