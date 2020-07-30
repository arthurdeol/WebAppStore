using FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string adress)
        {
            Adress = adress;

            new ValidationContract<Email>(this)
            .IsRequired(x => x.Adress, "E-mail inválido");
        }
        public string Adress { get; private set; }
        
    }
}
