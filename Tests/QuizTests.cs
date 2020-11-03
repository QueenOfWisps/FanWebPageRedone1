using FanWebPageRedone.Models;
using System;
using Xunit;


namespace Tests
{
    public class QuizTests
    {
        [Fact]
        //right answer test for user 
        public void RightAnswerTest()
        {
            //arrange
            var quiz = new QuizVM()
            {
                UserAnswer1 = "born to die",
                UserAnswer2 = "yes",
                UserAnswer3 = "white mustang"

            };
            quiz.CheckAnswers();

            //assert
            Assert.True("Right" == quiz.RightOrWrong1 && "Right" == quiz.RightOrWrong2 && "Right" == quiz.RightOrWrong3);   


        }
        //wrong answer test for user
        [Fact]
        public void WrongAnswerTest()
        {
            //arrange
            var quiz = new QuizVM()
            {
                UserAnswer1 = "ultraviolence",
                UserAnswer2 = "no she hates them",
                UserAnswer3 = "summertime sadness"

            };
            quiz.CheckAnswers();

            //assert
            Assert.True("Wrong" == quiz.RightOrWrong1 && "Wrong" == quiz.RightOrWrong2 && "Wrong" == quiz.RightOrWrong3);



        }
    }
}
