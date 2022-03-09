using EvoSystems.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoSystems.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder SeedData(this ModelBuilder builder) 
        {
            builder.Entity<Users>()
                .HasData(
                    new Users { Id = Guid.Parse("acaf2a77-b7e8-4ca2-9698-3b3910df5142"), Nome = "Tecnologia Da Informação", Silgla = "T.I", DateCreated = new DateTime(2022,3,9), IsDeleted = false, DateUpdated = null}
                );
            return builder;
        }
    }
}
