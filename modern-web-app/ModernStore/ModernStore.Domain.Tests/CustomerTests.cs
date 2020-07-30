using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;

namespace ModernStore.Domain.Tests
{
    [TestClass]
    public class CustomerTests
    {
        private readonly User user = new User("arthurdeoliveira", "arthurdeoliveira", "arthurdeoliveira");
        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidFirstNameShouldReturnANotification()
        {  
            var customer = 
            new Customer(
                new Name("", "de Oliveira"),
                new Email("arthurdeol@gmail.com"),
                new Document("09384270679"),
                new User("arthurdeol", "arthurdeol", "arthurdeol")
                );
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidLastNameShouldReturnANotification()
        {
            var customer =
                new Customer(
                new Name("Arthur", ""),
                new Email("arthurdeol@gmail.com"),
                new Document("09384270679"),
                new User("arthurdeol", "arthurdeol", "arthurdeol")
                );
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidEmailShouldReturnANotification()
        {
            var customer =
                new Customer(
                new Name("Arthur", "de Oliveira"),
                new Email(""),
                new Document("09384270679"),
                new User("arthurdeol", "arthurdeol", "arthurdeol")
                );
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidDocumentShouldReturnANotification()
        {
            var customer =
                new Customer(
                new Name("Arthur", "de Oliveira"),
                new Email("arthurdeol@gmail.com"),
                new Document("12345678911"),
                new User("arthurdeol", "arthurdeol", "arthurdeol")
                );
            Assert.IsFalse(customer.IsValid());
        }
    }
}
