using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            // Prepare
            appManager.Auth.Logout();

            // Action
            AccountData account = new AccountData("admin", "secret");
            appManager.Auth.Login(account);

            // Verification
            Assert.IsTrue(appManager.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            // Prepare
            appManager.Auth.Logout();

            // Action
            AccountData account = new AccountData("admin", "123456");
            appManager.Auth.Login(account);

            // Verification
            Assert.IsFalse(appManager.Auth.IsLoggedIn(account));
        }

    }
}
