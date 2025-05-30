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
    public class PersonelProjectMap : IEntityTypeConfiguration<PersonelProject>
    {
        public void Configure(EntityTypeBuilder<PersonelProject> builder)
        {

            builder.HasKey(c => new {c.ProjectId,c.PersonelId});



            builder.HasOne(pp => pp.Project)
                   .WithMany(p => p.PersonelProjects)
                   .HasForeignKey(pp => pp.ProjectId);


            builder.HasOne(pp => pp.Personel)
                .WithMany(p => p.PersonelProjects)
                .HasForeignKey(pp => pp.PersonelId);


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
