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
        }
    }
}
