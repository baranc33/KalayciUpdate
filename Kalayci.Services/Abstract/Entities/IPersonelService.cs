﻿using Kalayci.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Services.Abstract.Entities
{
    public interface IPersonelService : IGenericService<Personel>
    {
        Task<ICollection<Personel>> GettAllIncludeBranch();
       Task<ICollection<Personel>> GettBranchPersonels(int BranchId);

        Task<(Personel,bool,string)> UpdatePersonelWithProjectsAsync(Personel personel, int projectID, bool checkChangeManagerUserId);
    }
}
