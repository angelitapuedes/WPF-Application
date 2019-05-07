using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleMomSummer
{
    public class MomAccount
    {
        public string FirstNm { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string LastNm { get; set; }

        public int Age { get; set; }

        public int KidCnt { get; set; }

        public string Interest { get; set; }

        public MomAccount(string firstNm, string lastNm, int age, int kidCnt, string interest)
        {
            FirstNm = firstNm;
            LastNm = lastNm;
            Age = age;
            KidCnt = kidCnt;
            Interest = interest;
        }

        public MomAccount()
        {

        }
    }
}
