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
    public class SpoolMap : IEntityTypeConfiguration<Spool>
    {
        public void Configure(EntityTypeBuilder<Spool> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();




            builder.Property(r => r.Shipmentlocation).IsRequired(true);
            builder.Property(r => r.spoolStatus).IsRequired(true);
            builder.Property(r => r.SpoolName).IsRequired(true);
            builder.Property(r => r.SpoolName).HasMaxLength(150);

            builder.Property(r => r.CreatedByName).IsRequired(true);
            builder.Property(r => r.CreatedByName).HasMaxLength(100);
            builder.Property(r => r.ModifiedByName).IsRequired(true);
            builder.Property(r => r.ModifiedByName).HasMaxLength(100);
            builder.Property(r => r.CreatedDate).IsRequired(true);
            builder.Property(r => r.ModifiedDate).IsRequired(true);
            builder.Property(r => r.ModifiedDate).IsRequired(true);
            builder.Property(r => r.IsDeleted).IsRequired(true);

            builder
                .HasOne(a => a.WorkPlace).WithOne(u => u.spool)
                .HasForeignKey<WorkPlace>(s => s.spoolId);



            builder
                .HasOne(a => a.Welding).WithOne(u => u.spool)
                .HasForeignKey<Welding>(s => s.spoolId);

            builder
                .HasOne(a => a.CircuitDelivery).WithOne(u => u.spool)
                .HasForeignKey<CircuitDelivery>(s => s.spoolId);


            builder
                .HasOne(a => a.Sending).WithOne(u => u.spool)
                .HasForeignKey<Sending>(s => s.spoolId);



            builder
                .HasOne(a => a.ShipyardAssembly).WithOne(u => u.spool)
                .HasForeignKey<ShipyardAssembly>(s => s.spoolId);


            builder.HasOne<Project>(a => a.Project).WithMany(u => u.spoolLists).HasForeignKey(a => a.ProjectId);
            builder.HasOne<CircuitList>(a => a.CircuitList).WithMany(u => u.spoolLists).HasForeignKey(a => a.CircuitListId);
        }
    }
}
