using IAService;
using Microsoft.Extensions.DependencyInjection;
using Service;
using System;

namespace AddRegist
{
    public static class RegisterComm
    {
        public static void InjectionService(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();            
        }
    }
}
