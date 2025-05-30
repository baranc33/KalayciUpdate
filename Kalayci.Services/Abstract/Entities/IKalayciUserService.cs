using Kalayci.Entities.Concrete;
using Kalayci.Entities.Dto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Services.Abstract.Entities
{
    public interface IKalayciUserService : IGenericService<KalayciUser>
    {

        Task<ICollection<KalayciUser>> GetAllUser();
        Task<IdentityResult> CreateUser(UserSaveDto model);
        Task<KalayciUser> GettAllIncludePersonelThenIncludeBranch(string UserID);

        Task<string> Login(LoginDto model);
    }
}
