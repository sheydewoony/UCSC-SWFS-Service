using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCSC.SWFS.SRV.Entity.Context
{
    public class SWFSDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;
        public SWFSDbContext(IConfiguration configuration)
        {

        }
    }
}
