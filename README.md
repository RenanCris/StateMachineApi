#   StateMachineApi

This repository contains a sample usage of a state machine. It was based on repository *Stateless* , for more examples see: [Stateless](https://github.com/dotnet-state-machine/stateless) .

## Configuration State Machine

         _stateMachine.Configure(MembershipState.Active)
                .Permit(MemberTriggers.Suspend, MembershipState.Inactive)
                .Permit(MemberTriggers.Terminate, MembershipState.Terminated);

            _stateMachine.Configure(MembershipState.Inactive)
                .Permit(MemberTriggers.Reactivate, MembershipState.Active)
                .Permit(MemberTriggers.Terminate, MembershipState.Terminated);

            _stateMachine.Configure(MembershipState.Terminated)
                .OnEntry(() => ApplyRateTerminate())
                .Permit(MemberTriggers.Reactivate, MembershipState.Active);
                
## DotGraph                    



## To a test , locally

Use the docker image and run via api. 

    docker build -t machine:latest .
    docker run  --name mymachine -p 5000:5000 -p 8081:80 machine:latest