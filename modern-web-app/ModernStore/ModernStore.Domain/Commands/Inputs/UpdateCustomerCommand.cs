using ModernStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.Commands
{
    public class UpdateCustomerCommand : ICommand
    {
        public Guid Id { get; set; }
        public string LasstName { get; private set; }
        public string FirstName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string User { get; private set; }
        public string Email { get; private set; }
        public string Document { get; private set; }
    }
}
