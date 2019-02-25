using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newcontact = new ContactData("MMM", "MMM", "MMM")
            {
                Nickname = "MMM",
                Title = "MMM",
                Company = "MMM",
                Address = "MMM",
                Home = "MMM",
                Work = "MMM",
                Email = "MMM",
                Email2 = "MMM",
                Email3 = "MMM",
                Homepage = "MMM",
                Address2 = "MMM",
                Notes = "MMM",
                Bmonth = "October",
                Amonth = "October",
                Fax = "888",
                Mobile = "888",
                Phone2 = "888",
                Byear = "2222",
                Bday = "22",
                Ayear = "2222",
                Aday = "22"
            };

            appManager.Contacts.Modify(1, newcontact);
        }
    }
}
