using Kalayci.Data.Abstract;
using Kalayci.Data.Abstract.Entities;
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
        private IPersonelRepository _personelRepository;
        public PersonelService(IEntityRepository<Personel> repository, IUnitOfWork unitOfWork, IPersonelRepository personelRepository) : base(unitOfWork, repository)
        {
            _personelRepository=personelRepository;
        }

        public async Task<ICollection<Personel>> GettAllIncludeBranch()
        {
          return await _personelRepository.GettAllIncludeBranch();
        }

        public async Task<ICollection<Personel>> GettBranchPersonels(int BranchId)
        {
           return await _personelRepository.GettBranchPersonels(BranchId);
        }
    }
}
