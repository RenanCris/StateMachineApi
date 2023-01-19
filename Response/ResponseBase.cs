using StateMachineApi.Domain;

namespace StateMachineApi.Response
{
    public abstract class ResponseBase<TData>
    {
        public string Message { get; set; }
        public TData Data { get; set; }

        public string? DataDescription { get; set; }
    }

    public class MemberResponse : ResponseBase<Member> {

        public MemberResponse(bool changeState, Member member)
        {
            Message = changeState ? "O Status foi alterado!" : "Não foi possível alterar o status!";
            Data= member;
            DataDescription = Data?.ToString();
        }
    }
}
