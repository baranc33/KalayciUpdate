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
    public class KalayciUserMap : IEntityTypeConfiguration<KalayciUser>
    {
        public void Configure(EntityTypeBuilder<KalayciUser> builder)
        {






            builder.Property(r => r.Linkedin).HasMaxLength(100);
            
            builder.Property(r => r.PasswordBackUp).IsRequired(true);
            builder.Property(r => r.PasswordBackUp).HasMaxLength(100);


            



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
