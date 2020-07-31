using Dapper;
using ModernStore.Domain.Commands.Results;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModerStore.Infra.Contexts;
using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;

namespace ModerStore.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ModernStoreDataContext _context;

        public CustomerRepository(ModernStoreDataContext context)
        {
            _context = context;
        }

        public bool DocumentExists(string document)
        {
            return _context.Customers.Any(x => x.Document.Number == document);
        }

        public Customer Get(Guid id)
        {
            return _context.Customers.Include(x => x.User).FirstOrDefault(x => x.Id == id);
        }

        public GetCustomerCommandResult Get(string username)
        {
            //return _context.Customers.Include(x => x.User).AsNoTracking().Select(x => new GetCustomerCommandResult
            //{
            //    Name = x.Name.ToString(),
            //    Document = x.Document.Number,
            //    Active = x.User.Active,
            //    Email = x.Email.Adress,
            //    Password = x.User.Password,
            //    UserName = x.User.Username
            //}).FirstOrDefault(x => x.UserName == username);

            var query = @"Select * FROM [GETCUSTOMERINFORVIEW] WHERE [ACTIVE] = 1 AND [USERNAME] = @username";

            using (var conn = new SqlConnection(@""))
            {
                conn.Open();
                return conn.Query<GetCustomerCommandResult>(query, new { username = username }).FirstOrDefault();
            }
        }

        public void Save(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }
    }
}
