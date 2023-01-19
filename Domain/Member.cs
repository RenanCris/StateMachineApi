using Stateless;
using Stateless.Graph;
using StateMachineApi.Domain.Services;

namespace StateMachineApi.Domain
{
    public class Member
    {
        public MembershipState Status
        {
            get
            {
                return _stateMachine.State;
            }
        }
        public MemberTriggers MemberTriggers { get; set; }

        private readonly StateMachine<MembershipState, MemberTriggers> _stateMachine;
        public decimal Rate { get; set; } = 200;

        public Member(MembershipState state)
        {
            _stateMachine = new StateMachine<MembershipState, MemberTriggers>(state);
            ConfigureStateMachine();
        }

        private void ConfigureStateMachine()
        {
            _stateMachine.Configure(MembershipState.Active)
                .Permit(MemberTriggers.Suspend, MembershipState.Inactive)
                .Permit(MemberTriggers.Terminate, MembershipState.Terminated);

            _stateMachine.Configure(MembershipState.Inactive)
                .Permit(MemberTriggers.Reactivate, MembershipState.Active)
                .Permit(MemberTriggers.Terminate, MembershipState.Terminated);

            _stateMachine.Configure(MembershipState.Terminated)
                .OnEntry(() => ApplyRateTerminate())
                .Permit(MemberTriggers.Reactivate, MembershipState.Active);
        }

        private void ApplyRateTerminate() => Rate -= 30;

        public bool TryUpdateOrderStatus(MemberTriggers trigger)
        {
            if (!_stateMachine.CanFire(trigger))
                return false;

            _stateMachine.Fire(trigger);
            return true;
        }

        public string ToDotGraph => UmlDotGraph.Format(_stateMachine.GetInfo());

        public override string ToString()
        {
            return $"State: {Status}, Rate: { Rate}";
        }
    }
}
