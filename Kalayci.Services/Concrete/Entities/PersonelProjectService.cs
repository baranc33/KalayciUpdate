using Kalayci.Data.Abstract;
using Kalayci.Data.Abstract.Entities;
using Kalayci.Data.Concrete;
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
    public class PersonelProjectService : GenericService<PersonelProject>, IPersonelProjectService
    {
        private readonly IPersonelProjectRepository _personelProjectRepository;
        private readonly IUnitOfWork _unitOfWork;
        public PersonelProjectService(IEntityRepository<PersonelProject> repository, IUnitOfWork unitOfWork,
            IPersonelProjectRepository personelProjectRepository) : base(unitOfWork, repository)
        {
            _unitOfWork= unitOfWork;
            _personelProjectRepository = personelProjectRepository;
        }

        public async Task<PersonelProject> ActivePersonelProjectInculude(int personelId)
        {

            return await _personelProjectRepository.ActivePersonelProjectInculude(personelId);
        }

        public async Task<bool> AutomaticPersonFiilProject()
        {
            await _personelProjectRepository.AutomaticPersonFiilProject();
            int result = await _unitOfWork.SaveAsync();
            return result > 0 ? true : false;
        }
    }
}
