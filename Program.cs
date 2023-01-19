using MediatR;
using StateMachineApi.Application.UseCases;
using StateMachineApi.Domain;
using StateMachineApi.Machine.Extensions;
using StateMachineApi.Response;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMachineConfig();
builder.Services.AddMediatR(typeof(TerminateMemberUseCase));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("v1/members/activation", (IMediator mediator) =>
{
    return Results.Ok(new MemberResponse(true, new Member(MembershipState.Active)));
});

app.MapPost("v1/members/finalization", async (IMediator mediator) =>
{
    var member = await mediator.Send(new TerminateMemberUseCase());
    return Results.Ok(member);
});

app.MapPost("v1/members/reactivation", async (IMediator mediator) =>
{
    var member = await mediator.Send(new ReactiveMemberUseCase());
    return Results.Ok(member);
});


app.UseAuthorization();
app.Run();
