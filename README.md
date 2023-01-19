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
![image](https://user-images.githubusercontent.com/7238977/213438903-17de5f2e-8a2b-4be7-90fa-19a41219729b.png)


## Api

![image](https://user-images.githubusercontent.com/7238977/213439042-65734180-f580-4489-a348-b3944ce136d4.png)

![image](https://user-images.githubusercontent.com/7238977/213439082-eb2c6040-b1e6-4122-a0e7-e4d7d737505b.png)


## To a test , locally

Use the docker image and run via api. 

    docker build -t machine:latest .
    docker run  --name mymachine -p 5000:5000 -p 8081:80 machine:latest
    
    
