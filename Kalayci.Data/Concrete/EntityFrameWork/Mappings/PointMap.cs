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
    public class PointMap : IEntityTypeConfiguration<Point>
    {
        public void Configure(EntityTypeBuilder<Point> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();




            builder.Property(r => r.TeamWorkPoint).IsRequired(true);
            builder.Property(r => r.JabTrackingPoint).IsRequired(true);
            builder.Property(r => r.ContinuityPoint).IsRequired(true);
            builder.Property(r => r.AveragePoint).IsRequired(true);




            builder.Property(r => r.GiveDateStart).IsRequired(true);
            builder.Property(r => r.GiveDateFinish).IsRequired(true);




            builder.Property(r => r.CreatedByName).IsRequired(true);
            builder.Property(r => r.CreatedByName).HasMaxLength(100);
            builder.Property(r => r.ModifiedByName).IsRequired(true);
            builder.Property(r => r.ModifiedByName).HasMaxLength(100);
            builder.Property(r => r.CreatedDate).IsRequired(true);
            builder.Property(r => r.ModifiedDate).IsRequired(true);
            builder.Property(r => r.IsDeleted).IsRequired(true);

            builder.HasOne<Personel>(a => a.Personel).WithMany(u => u.points).HasForeignKey(a => a.PersonelId);
        }
    }
}
