using MediatR;
using StateMachineApi.Domain.Services;
using StateMachineApi.Domain;
using StateMachineApi.Response;

namespace StateMachineApi.Application.UseCases
{
    public class ReactiveMemberUseCase : IRequest<MemberResponse>
    {
    }

    public class ReactiveMemberHandler : IRequestHandler<ReactiveMemberUseCase, MemberResponse>
    {
        private readonly IReactivateService _service;
        public ReactiveMemberHandler(IReactivateService service)
        {
            _service = service;
        }

        public async Task<MemberResponse> Handle(ReactiveMemberUseCase request, CancellationToken cancellationToken)
        {
            var lastStateMember = MembershipState.Active;

            var member = new Member(lastStateMember);
            var isChangeState = member.TryUpdateOrderStatus(MemberTriggers.Reactivate);
            if (isChangeState)
            {
                await _service.ExecuteActionAsync(member);
            }

            return new MemberResponse(isChangeState,null);
        }
    }
}
