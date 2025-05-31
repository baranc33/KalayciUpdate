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
    public class PersonelMap : IEntityTypeConfiguration<Personel>
    {
        public void Configure(EntityTypeBuilder<Personel> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();



            builder.Property(r => r.Name).IsRequired(true);
            builder.Property(r => r.Name).HasMaxLength(50);

            builder.Property(r => r.LastName).IsRequired(true);
            builder.Property(r => r.LastName).HasMaxLength(50);





            builder.Property(r => r.Name).IsRequired(true);
            builder.Property(r => r.Name).HasMaxLength(50);

            builder.Property(r => r.Phone).HasMaxLength(15);
            builder.Property(r => r.Picture).HasMaxLength(2000);
            builder.Property(r => r.WorkStartDate).IsRequired(true);


            //builder.Property(r => r.AutorizedProject).IsRequired(true);
            //builder.Property(r => r.AutorizedProject).HasMaxLength(100);


            builder.Property(r => r.CreatedByName).IsRequired(true);
            builder.Property(r => r.CreatedByName).HasMaxLength(100);
            builder.Property(r => r.ModifiedByName).IsRequired(true);
            builder.Property(r => r.ModifiedByName).HasMaxLength(100);
            builder.Property(r => r.CreatedDate).IsRequired(true);
            builder.Property(r => r.ModifiedDate).IsRequired(true);
            builder.Property(r => r.IsDeleted).IsRequired(true);






            //builder.Property(r => r.SgkScilNo).IsRequired(true);
            //builder.Property(r => r.SgkScilNo).HasMaxLength(100);


            

            //builder.Property(r => r.TcNo).IsRequired(true);
            //builder.Property(r => r.TcNo).HasMaxLength(11);






            builder
          .HasOne(a => a.User).WithOne(u => u.personel)
          .HasForeignKey<KalayciUser>(s => s.personelId);





            builder.HasOne<Branch>(a => a.branch).WithMany(u => u.Personels).HasForeignKey(a => a.branchId);
            builder.HasOne<KalayciUser>(a => a.ManagerUser).WithMany(u => u.ManagePersonel).HasForeignKey(a => a.ManagerUserId);
            builder.HasData(
         new Personel
         {
             Id=1,
             Name="Bilgi",
             LastName="İşlem",
             Phone="555 004 63 33",
             Picture=null,
             WorkStartDate=DateTime.Now,
             WorkFinishDate=DateTime.Now.AddYears(100),
             branchId=1,



         }
           );

        }
    }
}
