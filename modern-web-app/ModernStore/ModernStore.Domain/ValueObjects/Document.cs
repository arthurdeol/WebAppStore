﻿using FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernStore.Domain.ValueObjects
{
    public class Document : Notifiable
    {
		protected Document() { }
		public string Number { get; private set; }

        public Document(string number)
        {
            Number = number;

			if(!Validate(number))
				AddNotification("Document", "CPF inválido");

        }

        public bool Validate(string cpf)
        {
			var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            cpf = cpf.Trim();
			cpf = cpf.Replace(".", "").Replace("-", "");
			if (cpf.Length != 11)
				return false;
            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (var i = 0; i < 9; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            int resto = soma % 11;
            if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
            string digito = resto.ToString();
            tempCpf = tempCpf + digito;
			soma = 0;
			for (var i = 0; i < 10; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();
			return cpf.EndsWith(digito);
		}
    }
}
