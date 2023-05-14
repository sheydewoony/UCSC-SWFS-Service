using UCSC.SWFS.SRV.API.Filters;
using UCSC.SWFS.SRV.Entity.Context;
using UCSC.SWFS.SRV.Repositories.UnitofWork;
using UCSC.SWFS.SRV.Utilities.RequestHeader;
using AutoMapper;
using UCSC.SWFS.SRV.Repositories.Implementation;
using UCSC.SWFS.SRV.Repositories.Intefaces;
using UCSC.SWFS.SRV.Service.Interfaces;
using UCSC.SWFS.SRV.Service.Implementation;
using UCSC.SWFS.SRV.Service.Common;

namespace UCSC.SWFS.SRV.API.Insfrastructure
{
    public static class RegisterDependancy
    {
        public static void AddAppDependencies(this IServiceCollection services)
        {
            services.AddScoped<IUnitofWork, UnitofWork<SWFSDbContext>>();
            services.AddScoped<RequestHeaderFilter>();
            services.AddScoped<IRequestHeader, RequestHeader>(); 
            services.AddAutoMapper(typeof(MappingProfile));

            #region Repositories

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();


            #endregion


            #region Services

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMQTTBrockerService, MQTTBrockerService>();
            services.AddScoped<IScheduleService, ScheduleService>();

            #endregion
        }
    }
}
