using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("aaa")
            {
                Header = "ddd",
                Footer = "fff"
            };

            List<GroupData> oldGroups = appManager.Groups.GetGroupList();

            appManager.Groups.Create(group);

            List<GroupData> newGroups = appManager.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
           
        }
        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("")
            {
                Header = "",
                Footer = ""
            };

            List<GroupData> oldGroups = appManager.Groups.GetGroupList();

            appManager.Groups.Create(group);

            List<GroupData> newGroups = appManager.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);

        }
        [Test]
        public void BadGroupCreationTest()
        {
            GroupData group = new GroupData("a'a")
            {
                Header = "",
                Footer = ""
            };

            List<GroupData> oldGroups = appManager.Groups.GetGroupList();

            appManager.Groups.Create(group);

            List<GroupData> newGroups = appManager.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);

        }

    }
}
