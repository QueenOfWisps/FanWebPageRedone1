using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanWebPageRedone.Models
{
    public class QuizVM
    {
        //
        public string UserAnswer1 { get; set; }
        public string RightOrWrong1 { get; set; }
        public string UserAnswer2 { get; set; }
        public string RightOrWrong2 { get; set; }
        public string UserAnswer3 { get; set; }
        public string RightOrWrong3 { get; set; }

        public void  CheckAnswers() 
        {
            RightOrWrong1 = UserAnswer1 == "born to die"?"Right":"Wrong";
            RightOrWrong2 = UserAnswer2 == "yes"?"Right":"Wrong";
            RightOrWrong3 = UserAnswer3 == "white mustang" ? "Right" : "Wrong";
        }

    }

}
