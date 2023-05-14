using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCSC.SWFS.SRV.Dto.Response
{
    public class ResponseDto<T>
    {
        public string Message { get; set; }
        public string MessageCode { get; set; }
        public bool Validity
        {
            get
            {
                if (ErrorList != null && ErrorList.Any())
                {
                    return false;
                }
                return true;
            }
        }
        public T ResultData { get; set; }
        public List<ErrorInfoDto> ErrorList { get; set; }
    }
}
