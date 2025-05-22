using Kalayci.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Shared.Utilitis.Result.Abstract
{
    public interface IResult
    {
        // bu veriler ctor içinde verilecek fakat daha sonra 
        // değiştirilemiceği için sadece get metodu yapıyoruz.
        public ResultStatus ResultStatus { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }
}
