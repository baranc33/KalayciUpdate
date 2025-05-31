using Kalayci.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Data.Concrete.EntityFrameWork.Mappings
{
    public class EmployeeExitMap : IEntityTypeConfiguration<EmployeeExit>
    {
        public void Configure(EntityTypeBuilder<EmployeeExit> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();




            builder.Property(r => r.PersonelId).IsRequired(true);
            builder.Property(r => r.StartWorkTime).IsRequired(true);
            builder.Property(r => r.FinishWorkTime).IsRequired(true);
            builder.Property(r => r.PersonelNoteAverage).IsRequired(true);



            builder.Property(r => r.CreatedByName).IsRequired(true);
            builder.Property(r => r.CreatedByName).HasMaxLength(100);
            builder.Property(r => r.ModifiedByName).IsRequired(true);
            builder.Property(r => r.ModifiedByName).HasMaxLength(100);
            builder.Property(r => r.CreatedDate).IsRequired(true);
            builder.Property(r => r.ModifiedDate).IsRequired(true);
            builder.Property(r => r.IsDeleted).IsRequired(true);


            builder.HasOne<Personel>(a => a.Personel).WithMany(u => u.employeeExits).HasForeignKey(a => a.PersonelId);

        }
    }
}
