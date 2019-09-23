using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("AAA", "BBB")
            {
                Middlename = "ccc",
                Nickname = "ddd",
                Title = "ddd",
                Company = "ddd",
                Address = "ddd",
                Home = "ddd",
                Work = "ddd",
                Email = "ddd",
                Email2 = "ddd",
                Email3 = "ddd",
                Homepage = "ddd",
                Address2 = "ddd",
                Notes = "ddd",
                Bmonth = "November",
                Amonth = "July",
                Fax = "123",
                Mobile = "234",
                Phone2 = "345",
                Byear = "1991",
                Bday = "1",
                Ayear = "2016",
                Aday = "15"
            };

            List<ContactData> oldContacts = appManager.Contacts.GetContactList();

            appManager.Contacts.Create(contact);

            List<ContactData> newContacts = appManager.Contacts.GetContactList();
            Assert.AreEqual(oldContacts.Count + 1, newContacts.Count);

        }
    }
}
