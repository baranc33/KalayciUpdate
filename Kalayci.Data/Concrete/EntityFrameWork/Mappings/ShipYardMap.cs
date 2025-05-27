using Kalayci.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Data.Concrete.EntityFrameWork.Mappings
{
    public class ShipYardMap : IEntityTypeConfiguration<ShipYard>
    {
        public void Configure(EntityTypeBuilder<ShipYard> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();




            builder.Property(r => r.ShipYardName).IsRequired(true);
            builder.Property(r => r.ShipYardName).HasMaxLength(150);

            builder.Property(r => r.CreatedByName).IsRequired(true);
            builder.Property(r => r.CreatedByName).HasMaxLength(100);
            builder.Property(r => r.ModifiedByName).IsRequired(true);
            builder.Property(r => r.ModifiedByName).HasMaxLength(100);
            builder.Property(r => r.CreatedDate).IsRequired(true);
            builder.Property(r => r.ModifiedDate).IsRequired(true);
            builder.Property(r => r.IsDeleted).IsRequired(true);


        }
    }
}
