using Kalayci.Data.Abstract;
using Kalayci.Data.Abstract.Entities;
using Kalayci.Data.Concrete.EntityFrameWork.Context;
using Kalayci.Entities.Concrete;
using Kalayci.Shared.Data.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Data.Concrete.EntityFrameWork.Repositories
{
    public class PersonelProjectRepository : EfEntityRepositoryBase<PersonelProject>, IPersonelProjectRepository
    {
        private readonly KalayciContext _context;
        public PersonelProjectRepository(KalayciContext context  ) : base(context)
        {
            _context= context;
        }

        public async Task<PersonelProject> ActivePersonelProjectInculude(int personelId)
        {

            PersonelProject personelProject = await _context.PersonelProjects.Where(x => x.PersonelId == personelId && x.IsActiveWork == true)
                .Include(x => x.Project)
                .Include(x => x.Personel)
                .SingleOrDefaultAsync();

            if (personelProject == null)
            {

                Personel Findpersonel = await _context.Personel.Where(x => x.Id==personelId).SingleOrDefaultAsync();
                Project project = await _context.Project.Where(x => x.ProjectName=="Boşta Kalan Personeller").FirstOrDefaultAsync();
                PersonelProject personelProjectNew = new PersonelProject()
                {
                    PersonelId = personelId,
                    IsActiveWork = true,
                    StartDate = DateTime.Now,
                    FinishDate = null,
                    BranchId =Findpersonel.branchId,
                    ProjectId=project.Id,
                    ManagerName="System Automatic",
                    CreatedByName = "System",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    ModifiedByName = "System",
                    IsDeleted = false

                };
                _context.PersonelProjects.Add(personelProjectNew);
                await _context.SaveChangesAsync();
                return personelProjectNew;

            }


            return personelProject;


        }

        public async Task<bool> AutomaticPersonFiilProject()
        {
            ICollection<Personel> personels = await _context.Personel.Where(x => x.IsDeleted == false && x.PersonelProjects.Count == 0).ToListAsync();
            Project project = await _context.Project.Where(x => x.ProjectName=="Boşta Kalan Personeller").FirstOrDefaultAsync();

            foreach (var item in personels)
            {
                PersonelProject personelProject = new PersonelProject()
                {

                    ProjectId = project.Id,
                    PersonelId = item.Id,
                    IsActiveWork = true,

                    StartDate = DateTime.Now,
                    FinishDate = null,
                    BranchId = item.branchId,

                    ManagerName = "System Automatic",



                    CreatedByName = "System",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    ModifiedByName = "System",
                    IsDeleted = false
                };

                if (item.ManagerUserId!=null)
                {
                    KalayciUser user = await _context.Users.Where(x => x.Id == item.ManagerUserId)
                  .Include(p => p.personel).SingleOrDefaultAsync();


                    personelProject.ManagerName=user.personel.Name+ " " + user.personel.LastName;
                }
                await _context.PersonelProjects.AddAsync(personelProject);
            }
            
        
        return true;
        }
    }
}
