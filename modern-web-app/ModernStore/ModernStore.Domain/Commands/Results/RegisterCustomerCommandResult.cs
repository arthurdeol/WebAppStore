using ModernStore.Shared.Commands;
using System;

namespace ModernStore.Domain.CommandResults
{
    public class RegisterCustomerCommandResult : ICommandResult
    {
        public RegisterCustomerCommandResult(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
