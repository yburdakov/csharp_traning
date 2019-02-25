using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            NewContactData newcontact = new NewContactData("AAA", "BBB", "CCC")
            {
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

            appManager.Contacts.Create(newcontact);
        }
    }
}
