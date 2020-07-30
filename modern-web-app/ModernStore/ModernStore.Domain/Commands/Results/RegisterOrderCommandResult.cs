using ModernStore.Shared.Commands;

namespace ModernStore.Domain.CommandResults
{
    public class RegisterOrderCommandResult : ICommandResult
    {
        public RegisterOrderCommandResult(string number)
        {
            Number = number;
        }

        public string Number { get; set; }
    }
}
