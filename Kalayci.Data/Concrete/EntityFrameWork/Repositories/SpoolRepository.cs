using Kalayci.Data.Abstract.Entities;
using Kalayci.Data.Concrete.EntityFrameWork.Context;
using Kalayci.Entities.Concrete;
using Kalayci.Entities.Dto;
using Kalayci.Shared.Data.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Data.Concrete.EntityFrameWork.Repositories
{
    public class SpoolRepository : EfEntityRepositoryBase<Spool>, ISpoolRepository
    {

        private KalayciContext _context;
       

        public SpoolRepository(KalayciContext context) : base(context)
        {
            _context=context;

        }

        public async Task<(bool, ICollection<Spool>,string)> AddRangeSpoolistAsync(ICollection<Spool> spools)
        {

            try
            {
                await _context.Spool.AddRangeAsync(spools);
                return (true, spools,"");
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                string message =$"Mps Group :// An error occurred while adding spools: {ex.Message}";
                return (false, spools, message);
            }
        }

 
        public async Task<ICollection<PersonelProject>> GetProjectAllPersonelAndAllSpool(int projectId)
        {

            // personelProjecten => Projeye Ait Bütün Personelleri Ekliyoruz.
            // PersonelProjecten => Projeyi Tahil Ediyoru => Projeden Terseneyi Dahil Ediyoruz
            // Projeceden => Spooleri Dahil Ediyoruz
            // Projeden => proje Sorumlusunun Kullanıcısını Dahil Ediyoruz.
            // spool Tablolorını Dahil Etmemiz gerekiyor.
            
            //Bismillah :)
            return await _context.PersonelProjects.Where(pr=>pr.ProjectId==projectId)
                .Include(per => per.Personel)
                .Include(proj => proj.Project)
                .ThenInclude(proj => proj.shipYard)
                .Include(proj => proj.Project)
                .ThenInclude(proj => proj.User)
                  .Include(proj => proj.Project)
                .ThenInclude(spools => spools.spoolLists)
                .ToListAsync();
      
        }
        // bize geriye spoolların nerde olduğunu gösteren 6 paremetre  lazım
        // ayrıca oran orantıda girilen spool Sayısına göre paremetrelerin %leri lazım  yani 6 parametre daha 
        //İlk olarak, B sayısından A sayısını çıkarırız: 120 – 80 = 40. 
        //Sonra bu farkı A'ya böleriz: 40 / 80 = 0,5. Son olarak, 0,5'i 100 ile çarparız ve %50 elde ederiz.

        public async Task<ProjectPercentageCalculate> ProjectPercentageCalculate(int projectId)
        {
            Project project = await _context.Project
                .Include(p => p.spoolLists)
                .FirstOrDefaultAsync(p => p.Id == projectId);

            int spools = project.spoolLists.Count();
            ProjectPercentageCalculate projectPercentageCalculate = new ProjectPercentageCalculate()
            {
                WorkPlaceCount = project.spoolLists.Count(w => w.spoolStatus==0 && w.IsDeleted==false),
                WeldingCount = project.spoolLists.Count(w => w.spoolStatus==1 &&w.IsDeleted==false),
                CircuitDeliveryCount = project.spoolLists.Count(w => w.spoolStatus==2 &&w.IsDeleted==false),
                SendingCount = project.spoolLists.Count(w => w.spoolStatus==3 &&w.IsDeleted==false),
                ShipyardAssemblyCount = project.spoolLists.Count(w => w.spoolStatus==4 &&w.IsDeleted==false),
                FinishCount = project.spoolLists.Count(w => w.spoolStatus==5 &&w.IsDeleted==false)
            };
            projectPercentageCalculate.WorkPlacePercentage = CalculatePercentage(spools, projectPercentageCalculate.WorkPlaceCount);
            projectPercentageCalculate.WeldingPercentage = CalculatePercentage(spools, projectPercentageCalculate.WeldingCount);
            projectPercentageCalculate.CircuitDeliveryPercentage = CalculatePercentage(spools, projectPercentageCalculate.CircuitDeliveryCount);
            projectPercentageCalculate.SendingPercentage = CalculatePercentage(spools, projectPercentageCalculate.SendingCount);
            projectPercentageCalculate.ShipyardAssemblyPercentage = CalculatePercentage(spools, projectPercentageCalculate.ShipyardAssemblyCount);
            projectPercentageCalculate.FinishPercentage = CalculatePercentage(spools, projectPercentageCalculate.FinishCount);
            return projectPercentageCalculate;


        }

        private decimal CalculatePercentage(int total, int part)
        {
            if (total == 0 || part==0) return 0; // Avoid division by zero
            if (total == part) return 100; // Avoid division by zero
                                                 //return (decimal)(part * 100) / total;
            return ((total-part)/(part)*100);

        }
    }
}
