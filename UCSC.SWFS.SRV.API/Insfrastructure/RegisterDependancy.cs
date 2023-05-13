using UCSC.SWFS.SRV.API.Filters;
using UCSC.SWFS.SRV.Entity.Context;
using UCSC.SWFS.SRV.Repositories.UnitofWork;
using UCSC.SWFS.SRV.Utilities.RequestHeader;

namespace UCSC.SWFS.SRV.API.Insfrastructure
{
    public static class RegisterDependancy
    {
        public static void AddAppDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUnitofWork, UnitofWork<SWFSDbContext>>();
            services.AddScoped<IRequestHeader, RequestHeader>(); 
            services.AddScoped<RequestHeaderFilter>();
        }
    }
}
