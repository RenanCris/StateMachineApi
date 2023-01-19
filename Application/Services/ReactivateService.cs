using StateMachineApi.Domain;
using StateMachineApi.Domain.Services;
using System.Text.Json;

namespace StateMachineApi.Application.Services
{
    public class ReactivateService : MachineServiceBase, IReactivateService
    {
        public ReactivateService(ILogger<MachineServiceBase> logger) : base(logger)
        {
        }

        protected override Task<bool> TriggerExecuteActionAsync(Member member)
        {
            _logger.LogInformation($"Executed by success!!! . Reactivated Member : {JsonSerializer.Serialize(member)}");

            return Task.FromResult(true);
        }
    }
}
