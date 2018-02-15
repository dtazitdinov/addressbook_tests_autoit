using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class ApplicationManager
    {
        public static string WINTITLE = "Free Address Book";
        private AutoItX3 aux;
        private GroupHelper groupHelper;

        public ApplicationManager()
        {
            aux = new AutoItX3();
            RunProgramAndWaitActivate();
            groupHelper = new GroupHelper(this);
        }

        public void Stop()
        {
            aux.ControlClick(WINTITLE, "", "[NAME:uxExitAddressButton]");
        }

        public AutoItX3 Aux
        {
            get
            {
                return aux;
            }
        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }

        private void RunProgramAndWaitActivate()
        {
            aux.Run(@"C:\Csharp_Training\FreeAddressBookPortable\AddressBook.exe", "", aux.SW_SHOW);
            //aux.Run(@"G:\Desktop\Csharp_Training\FreeAddressBookPortable\AddressBook.exe", "", aux.SW_SHOWNORMAL);

            aux.WinWait(WINTITLE);
            aux.WinActive(WINTITLE);
            //aux.WinActivate(WINTITLE);
            aux.WinWaitActive(WINTITLE);
        }
    }
}
