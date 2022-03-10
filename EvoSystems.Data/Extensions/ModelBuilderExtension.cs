﻿using EvoSystems.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;
using EvoSystems.Domain.Models;

namespace EvoSystems.Data.Extensions
{
    public static class ModelBuilderExtension
    {

        public static ModelBuilder ApplyGlobalConfigurations(this ModelBuilder builder)
        {
            foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
            {
                foreach (IMutableProperty property in entityType.GetProperties())
                {
                    switch (property.Name)
                    {
                        case nameof(Entity.Id):
                            property.IsKey();
                            break;
                        case nameof(Entity.DateUpdated):
                            property.IsNullable = true;
                            break;
                        case nameof(Entity.DateCreated):
                            property.IsNullable = false;
                            property.SetDefaultValue(DateTime.Now);
                            break;
                        case nameof(Entity.IsDeleted):
                            property.IsNullable = false;
                            property.SetDefaultValue(false);
                            break;
                        default:
                            break;
                    }
                }
            }

            return builder;

        }


        public static ModelBuilder SeedData(this ModelBuilder builder)
        {
                builder.Entity<Users>()
                    .HasData(
                        new Users { Id = Guid.Parse("acaf2a77-b7e8-4ca2-9698-3b3910df5142"), Nome = "Tecnologia Da Informação", Email = "andrewsvictorps@gmail.com", DateCreated = new DateTime(2022,3,9), IsDeleted = false, DateUpdated = null}
                    );
                return builder;
            }
        }
    }
