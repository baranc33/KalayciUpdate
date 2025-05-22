using Kalayci.Shared.Enums;
using Kalayci.Shared.Utilitis.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalayci.Shared.Utilitis.Result.Concrete
{
    public class Result : IResult
    {

        public Result(ResultStatus ResultStatus, string Message, Exception Exception)
        {
            this.ResultStatus = ResultStatus;
            this.Message = Message;
            this.Exception = Exception;
        }
        public Result(ResultStatus ResultStatus, string Message)
        {
            this.ResultStatus = ResultStatus;
            this.Message = Message;
        }
        public Result(ResultStatus ResultStatus)
        {
            this.ResultStatus = ResultStatus;
        }
        public ResultStatus ResultStatus { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }
}
