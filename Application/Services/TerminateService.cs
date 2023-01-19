using StateMachineApi.Domain;
using StateMachineApi.Domain.Services;
using System.Text.Json;

namespace StateMachineApi.Application.Services
{
    public class TerminateService : MachineServiceBase, ITerminateService
    {
        public TerminateService(ILogger<MachineServiceBase> logger) : base(logger)
        {
        }

        protected override Task<bool> TriggerExecuteActionAsync(Member member)
        {
            _logger.LogInformation($"Executed by success!!! . Terminate Member : {JsonSerializer.Serialize(member)}");

            return Task.FromResult(true);
        }
    }
}
