using StateMachineApi.Domain;
using StateMachineApi.Domain.Services;

namespace StateMachineApi.Application.Services
{
    public abstract class MachineServiceBase : IMachineFlowService
    {
        protected readonly ILogger<MachineServiceBase> _logger;

        protected MachineServiceBase(ILogger<MachineServiceBase> logger) 
        {
            _logger = logger;
        }

        protected abstract Task<bool> TriggerExecuteActionAsync(Member member);

        public async Task<bool> ExecuteActionAsync(Member member)
        {
            _logger.LogInformation($"[{this.GetType().Name}] STARTED");

            var result =  await TriggerExecuteActionAsync(member);

            _logger.LogInformation($"[{this.GetType().Name}] ENDED");

            return result;
        }
    }
}
