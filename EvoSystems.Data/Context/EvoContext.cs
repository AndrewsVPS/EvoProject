using EvoSystems.Data.Extensions;
using EvoSystems.Data.Mappings;
using EvoSystems.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoSystems.Data.Context
{
    public class EvoContext : DbContext
    {
        public EvoContext (DbContextOptions<EvoContext> option)
            : base(option) { }

        #region "DBSets"

        public DbSet<Departamento> Departamento { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartamentoMap());

            modelBuilder.ApplyConfiguration(new FuncionáriosMap());

            modelBuilder.ApplyGlobalConfigurations();


            base.OnModelCreating(modelBuilder);
        }
    }
}
