namespace StateMachineApi.Domain.Services
{
    public interface IMachineFlowService
    {
        Task<bool> ExecuteActionAsync(Member member);
    }
}
