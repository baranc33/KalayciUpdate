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
    public class KalayciRoleMap : IEntityTypeConfiguration<KalayciRole>
    {
        public void Configure(EntityTypeBuilder<KalayciRole> builder)
        {



            builder.HasData(
              new KalayciRole
              {
                  Id = "1",
                  Name = "Admin",
                  NormalizedName = "ADMIN",
                  ConcurrencyStamp = Guid.NewGuid().ToString()
              },
              new KalayciRole
              {
                  Id = "2",
                  Name = "Yonetici",
                  NormalizedName = "YONETICI",
                  ConcurrencyStamp = Guid.NewGuid().ToString()
              }, new KalayciRole
              {
                  Id = "3",
                  Name = "Muhendis",
                  NormalizedName = "MUHENDIS",
                  ConcurrencyStamp = Guid.NewGuid().ToString()
              }, new KalayciRole
              {
                  Id = "4",
                  Name = "Atolye",
                  NormalizedName = "ATOLYE",
                  ConcurrencyStamp = Guid.NewGuid().ToString()
              }
              , new KalayciRole
              {
                  Id = "5",
                  Name = "Müşteri",
                  NormalizedName = "MUSTERI",
                  ConcurrencyStamp = Guid.NewGuid().ToString()
              }
                );
        }
    }
}
