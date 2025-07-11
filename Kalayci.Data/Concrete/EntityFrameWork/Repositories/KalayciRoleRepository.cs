﻿using Kalayci.Data.Abstract.Entities;
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
    public class KalayciRoleRepository : EfEntityRepositoryBase<KalayciRole>, IKalayciRoleRepository
    {

        public KalayciRoleRepository(KalayciContext context) : base(context)
        {
        }
    }
}
