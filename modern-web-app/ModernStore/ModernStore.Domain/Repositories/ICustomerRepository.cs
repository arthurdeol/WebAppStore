﻿using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;
using System;

namespace ModernStore.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(Guid id);
        bool DocumentExists(string document);
        void Update(Customer customer);
        void Save(Customer customer);
        GetCustomerCommandResult Get(string username);//alterar para document
    }
}
