using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UserCreationTests : TestBase
    {
        [Test]
        public void UserCreationTest()
        {
            GotoHomePage();
            Login(new AccountData("admin", "secret"));
            InitNewUserCreation();
            NewUserData newuser = new NewUserData("AAA", "BBB", "CCC");
                newuser.Nickname = "ddd";
                newuser.Title = "ddd";
                newuser.Company = "ddd";
                newuser.Address = "ddd";
                newuser.Home = "ddd";
                newuser.Work = "ddd";
                newuser.Email = "ddd";
                newuser.Email2 = "ddd";
                newuser.Email3 = "ddd";
                newuser.Homepage = "ddd";
                newuser.Address2 = "ddd";
                newuser.Notes = "ddd";
                newuser.Bmonth = "November";
                newuser.Amonth = "July";
                newuser.Fax = "123";
                newuser.Mobile = "234";
                newuser.Phone2 = "345";
                newuser.Byear = "1991";
                newuser.Bday = "1";
                newuser.Ayear = "2016";
                newuser.Aday = "15";
            FillNewUserForm(newuser);
            SubmitNewUserCreation();
            Logout();
        }
    }
}
