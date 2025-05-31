using Kalayci.Entities.Concrete;
using Kalayci.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Data.Abstract.Entities
{
    public interface IKalayciUserRepository : IEntityRepository<KalayciUser>
    {
        Task<KalayciUser> IncludePersonelThenIncludeBranch(string UserID);
        Task<ICollection<KalayciUser>> GetAllIncludePersonelThenIncludeBranch( );


    }
}
