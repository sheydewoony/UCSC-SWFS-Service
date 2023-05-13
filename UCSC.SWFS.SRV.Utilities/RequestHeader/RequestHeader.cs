using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCSC.SWFS.SRV.Utilities.RequestHeader
{
    public interface RequestHeader : IRequestHeader
    {
        public int UserId { get; set; }
    }
}
