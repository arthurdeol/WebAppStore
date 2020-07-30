using FluentValidator;
using ModernStore.Domain.CommandResults;
using ModernStore.Domain.Commands;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.Resources;
using ModernStore.Domain.Services;
using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Commands;

namespace ModernStore.Domain.CommandHandlers
{
    public class CustomerCommandHandler : Notifiable,
        ICommandHandler<UpdateCustomerCommand>,
        ICommandHandler<RegisterCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailService;

        public CustomerCommandHandler(ICustomerRepository customerRepository, IEmailService emailService)
        {
            _emailService = emailService;
            _customerRepository = customerRepository;
        }

        public ICommandResult Handle(UpdateCustomerCommand command)
        {
            //Passo 1. Recuperar o cliente
            var customer = _customerRepository.Get(command.Id);
            //Passo 2. Caso o cliente não existe
            if(customer == null)
            {
                AddNotification("Customer", "Cliente não encontrado");
                return null;
            }
            //Passo 3. Ataulizar a entidade
            var name = new Name(command.FirstName, command.LasstName);
            customer.Update(name, command.BirthDate);
            //Passo 4. Adicionar as notificações
            AddNotifications(customer.Notifications);
            //Passo 5. Persistir no banco
            if (IsValid())
                _customerRepository.Update(customer);
            //Passo 6. Retornar algo
            return new RegisterCustomerCommandResult(customer.Id, customer.Name.ToString());
        }

        public ICommandResult Handle(RegisterCustomerCommand command)
        {

            //Passo 1. Verifica se o CPF já existe
            if(_customerRepository.DocumentExists(command.Document))
            {
                AddNotification("Customer", "Cliente não encontrado");
                return null;
            }
            //Passo 2. Gerar o novo Cliente
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var user = new User(command.UserName, command.Password, command.ConfirmPassword);
            var customer = new Customer(name, email, document, user);

            //Passo 3. Adicionar as notificações
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(user.Notifications);
            AddNotifications(customer.Notifications);

            //Passo 4. Inserir no banco
            if (IsValid())
                _customerRepository.Save(customer);

            //Passo 5. Enviar E-mail de boas vindas
            _emailService.Send(
                customer.Name.ToString(),
                customer.Email.Adress,
                string.Format(EmailTemplates.WelcomeEmailTitle, customer.Name),
                string.Format(EmailTemplates.WelcomeEmailBody, customer.Name));
            //Passo 6. Retornar algo
            return new RegisterCustomerCommandResult(customer.Id, customer.Name.ToString());
        }
    }
}
