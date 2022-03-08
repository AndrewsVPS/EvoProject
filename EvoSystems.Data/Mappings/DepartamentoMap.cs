using EvoSystems.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoSystems.Data.Mappings
{
    public class DepartamentoMap : IEntityTypeConfiguration<Departamento>
    { 
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();

        }
        
    }
}
