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
    public class BranchMap : IEntityTypeConfiguration<Branch>
    {



        public void Configure(EntityTypeBuilder<Branch> builder)
        {


            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();


            builder.Property(r => r.BranchName).IsRequired(true);
            builder.Property(r => r.BranchName).HasMaxLength(100);



            builder.Property(r => r.BranchDetay).IsRequired(true);
            builder.Property(r => r.BranchDetay).HasMaxLength(1000);


            builder.Property(r => r.CreatedByName).IsRequired(true);
            builder.Property(r => r.CreatedByName).HasMaxLength(100);
            builder.Property(r => r.ModifiedByName).IsRequired(true);
            builder.Property(r => r.ModifiedByName).HasMaxLength(100);
            builder.Property(r => r.CreatedDate).IsRequired(true);
            builder.Property(r => r.ModifiedDate).IsRequired(true);
            builder.Property(r => r.IsDeleted).IsRequired(true);



            builder.HasData(
              new Branch
              {
                  Id=1,
                  ModifiedDate = DateTime.Now,
                  CreatedDate = DateTime.Now,
                  BranchName = "Bilgi işlem",
                  BranchDetay="Bilgi işlem departmanı, şirketin bilgi teknolojileri altyapısını yönetir ve destekler.",
                  IsDeleted = false,
                  CreatedByName = "System",
                  ModifiedByName = "System"
              },
            new Branch
            {
                Id=2,
                ModifiedDate = DateTime.Now,
                CreatedDate = DateTime.Now,
                BranchName = "Mühendis",
                BranchDetay="Boru Donatım Mühendisi.",
                IsDeleted = false,
                CreatedByName = "System",
                ModifiedByName = "System"
            }
                );

        }
    }
}
