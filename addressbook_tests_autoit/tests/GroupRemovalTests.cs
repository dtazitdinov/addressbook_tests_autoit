using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            //appManager.Groups.CheckGroupPresent();
            List<GroupData> oldGroups = appManager.Groups.GetGroupsList();

            GroupData toBeRemoved = oldGroups[0];

            appManager.Groups.Remove(toBeRemoved.Name);

            List<GroupData> newGroups = appManager.Groups.GetGroupsList();

            oldGroups.Remove(toBeRemoved);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
