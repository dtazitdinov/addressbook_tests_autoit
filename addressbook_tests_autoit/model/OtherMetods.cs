using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
    public class OtherMetods
    {
        private static Random rndNumber = new Random();

        public static string RandomNumber(int maxNum)
        {
            return rndNumber.Next(maxNum).ToString();
        }
    }
}

