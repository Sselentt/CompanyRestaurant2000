using CompanyRestaurant.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRestaurant.DAL.Configurations
{
    public class TableConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.HasMany(t => t.Orders)
              .WithOne(o => o.Table)
              .HasForeignKey(o => o.TableId);

            builder.HasMany(t => t.Rezervations)
                   .WithOne(r => r.Table)
                   .HasForeignKey(r => r.TableId);

            //Seed Data
            builder.HasData(SeedTableData());
        }

        public List<Table> SeedTableData()
        {
            List<Table> tables = new List<Table>()
            {
                new Table{ID=1,TableNo=1,RezStatus=true,PersonCapacity=4},
                new Table{ID=2, TableNo=2,RezStatus =false, PersonCapacity=2}

            };

            return tables;
        }

    }
}
