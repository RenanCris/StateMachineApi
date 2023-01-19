using MediatR;
using StateMachineApi.Domain;
using StateMachineApi.Domain.Services;
using StateMachineApi.Response;

namespace StateMachineApi.Application.UseCases
{
    public class TerminateMemberUseCase : IRequest<MemberResponse>
    {
    }

    public class TerminateMemberHandler : IRequestHandler<TerminateMemberUseCase, MemberResponse>
    {
        private readonly ITerminateService _terminateService;
        public TerminateMemberHandler(ITerminateService terminateService)
        {
            _terminateService = terminateService;
        }
        
        public async Task<MemberResponse> Handle(TerminateMemberUseCase request, CancellationToken cancellationToken)
        {
            var lastStateMember = MembershipState.Active;

            var member = new Member(lastStateMember);
            var isChangeState = member.TryUpdateOrderStatus(MemberTriggers.Terminate);

            if (isChangeState)
            {
                await _terminateService.ExecuteActionAsync(member);
            }

            return new MemberResponse(isChangeState, member);
        }
    }


}
