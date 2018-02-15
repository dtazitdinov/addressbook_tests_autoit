using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    
    public class TestBase
    {
        public ApplicationManager appManager;

        [TestFixtureSetUp]
        public void InitApplication()
        {
            appManager = new ApplicationManager();
        }

        [TestFixtureTearDown]
        public void stopApplication()
        {
            appManager.Stop();
        }
    }
}
