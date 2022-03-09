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
    public class UsersMap : IEntityTypeConfiguration<Users>
    { 
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();

        }
        
    }
}
