using StateMachineApi.Application.Services;
using StateMachineApi.Domain.Services;

namespace StateMachineApi.Machine.Extensions
{
    public static class MachineConfigExtensioncs
    {
        public static IServiceCollection AddMachineConfig(this IServiceCollection services)
        {
            services.AddScoped<ITerminateService, TerminateService>();
            services.AddScoped<IReactivateService, ReactivateService>();
            return services;
        }
    }
}
