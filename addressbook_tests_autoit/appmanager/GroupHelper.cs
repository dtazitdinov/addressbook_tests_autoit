using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string DELETEGROUPWINTITLE = "Delete group";

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void Add(GroupData group)
        {
            OpenGroupsEditor();
            aux.ControlClick(GROUPWINTITLE, "", "[NAME:uxNewAddressButton]");
            aux.Send(group.Name);
            aux.Send("{Enter}");
            CloseGroupsEditor();
        }

        private void OpenGroupsEditor()
        {
            aux.ControlClick(WINTITLE, "", "[NAME:groupButton]");
            aux.WinWait(GROUPWINTITLE);
        }

        private void CloseGroupsEditor()
        {
            aux.ControlClick(GROUPWINTITLE, "", "[NAME:uxCloseAddressButton]");
        }

        public List<GroupData> GetGroupsList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsEditor();
            string count = aux.ControlTreeView(GROUPWINTITLE, "", "[NAME:uxAddressTreeView]", "GetItemCount", "#0", "");
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(GROUPWINTITLE, "", "[NAME:uxAddressTreeView]", "GetText", "#0|#" + i, "");
                list.Add(new GroupData()
                {
                    Name = item
                });
            }
            CloseGroupsEditor();

            return list;
        }

        public void Remove(string groupName)
        {
            OpenGroupsEditor();

            string count = aux.ControlTreeView(GROUPWINTITLE, "", "[NAME:uxAddressTreeView]", "GetItemCount", "#0", "");
            for (int index = 0; index < int.Parse(count); index++)
            {
                if(groupName == aux.ControlTreeView
                    (GROUPWINTITLE, "", "[NAME:uxAddressTreeView]", "GetText", "#0|#" + index, ""))
                {
                    SelectGroup(index);
                    break;
                }
            }

            aux.ControlClick(GROUPWINTITLE, "", "[NAME:uxDeleteAddressButton]");
            aux.WinWaitActive(DELETEGROUPWINTITLE);
            aux.ControlClick(DELETEGROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.ControlClick(DELETEGROUPWINTITLE, "", "[NAME:uxOKAddressButton]");
            aux.WinWaitActive(GROUPWINTITLE);
            CloseGroupsEditor();
        }

        public void SelectGroup(int index)
        {
            aux.ControlTreeView(GROUPWINTITLE, "", "[NAME:uxAddressTreeView]", "Select", $"#0|#{index}", "");
        }
    }
}
