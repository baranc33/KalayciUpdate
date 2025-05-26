using Kalayci.Data.Abstract;
using Kalayci.Entities.Concrete;
using Kalayci.Services.Abstract.Entities;
using Kalayci.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Services.Concrete.Entities
{
    public class PersonelService : GenericService<Personel>, IPersonelService
    {
        public PersonelService(IEntityRepository<Personel> repository, IUnitOfWork unitOfWork) : base(unitOfWork, repository)
        { }
    }
}
