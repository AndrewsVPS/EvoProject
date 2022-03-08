using EvoSystems.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoSystems.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder SeedData(this ModelBuilder builder) 
        {
            builder.Entity<Departamento>()
                .HasData(
                    new Departamento { Id = Guid.Parse("acaf2a77-b7e8-4ca2-9698-3b3910df5142"), Nome = "Tecnologia Da Informação", Silgla = "T.I" }
                );
            return builder;
        }
    }
}
