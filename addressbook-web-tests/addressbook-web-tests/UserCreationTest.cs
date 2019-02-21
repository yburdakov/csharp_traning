using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UserCreationTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void UserCreationTest()
        {
            OpenHomePage();
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
            //please use correct months names for these below
            //cause I don't know how to manage dropdowns yet)))
                newuser.Bmonth = "November";
                newuser.Amonth = "July";
            //please use integer for these below, 
            //cause I don't know how to manage formats 
            //and how to consider fields validation)))
                newuser.Fax = "123";
                newuser.Mobile = "234";
                newuser.Phone2 = "345";
                newuser.Byear = "1991";
                newuser.Bday = "1"; // when using <0 or >[max for a mo] step must fail
                newuser.Ayear = "2016";
                newuser.Aday = "15"; // when using <0 or >[max for a mo] step must fail
            FillNewUserForm(newuser);
            SubmitNewUserCreation();
            Logout();
        }

        private void SubmitNewUserCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
        }

        private void FillNewUserForm(NewUserData newuser)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(newuser.Firstname);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(newuser.Middlename);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(newuser.Lastname);
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(newuser.Nickname);
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys(newuser.Title);
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(newuser.Company);
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(newuser.Address);
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(newuser.Home);
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(newuser.Mobile);
            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys(newuser.Work);
            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys(newuser.Fax);
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(newuser.Email);
            driver.FindElement(By.Name("email2")).Clear();
            driver.FindElement(By.Name("email2")).SendKeys(newuser.Email2);
            driver.FindElement(By.Name("email3")).Clear();
            driver.FindElement(By.Name("email3")).SendKeys(newuser.Email3);
            driver.FindElement(By.Name("homepage")).Clear();
            driver.FindElement(By.Name("homepage")).SendKeys(newuser.Homepage);
            driver.FindElement(By.Name("address2")).Clear();
            driver.FindElement(By.Name("address2")).SendKeys(newuser.Address2);
            driver.FindElement(By.Name("phone2")).Clear();
            driver.FindElement(By.Name("phone2")).SendKeys(newuser.Phone2);
            driver.FindElement(By.Name("notes")).Clear();
            driver.FindElement(By.Name("notes")).SendKeys(newuser.Notes);
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys(newuser.Byear);
            driver.FindElement(By.Name("ayear")).Clear();
            driver.FindElement(By.Name("ayear")).SendKeys(newuser.Ayear);
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(newuser.Bday);
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(newuser.Bmonth);
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(newuser.Aday);
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(newuser.Amonth);
        }

        private void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        private void InitNewUserCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        private void Login(AccountData account)
        {
            driver.FindElement(By.Name("user")).Click();
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
