using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupCreationTests :TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            List<GroupData> oldGroups = appManager.Groups.GetGroupsList();

            GroupData newGroup = new GroupData()
            {
                Name = $"Group {OtherMetods.RandomNumber(1000)}"
            };           
            
            appManager.Groups.Add(newGroup);

            //Assert.AreEqual(oldGroups.Count + 1, appManager.Group.GetGroupsCount());

            List<GroupData> newGroups = appManager.Groups.GetGroupsList();
            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
