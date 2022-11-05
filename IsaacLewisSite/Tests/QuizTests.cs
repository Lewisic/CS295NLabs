using IsaacLewisSite.Models;
using System;
using System.IO.MemoryMappedFiles;
using Xunit;

namespace Tests
{
    public class QuizTests
    {
        [Fact]
        public void RightAnswerTest()
        {
            const string Right = "Right";
            var quiz = new QuizVM()
            {
                UserAnswer1 = "Ben Kenobi",
                UserAnswer2 = "Tatooine",
                UserAnswer3 = "Ben Solo",
                UserAnswer4 = "Carbonite"
            };

            quiz.CheckAnswers();

            Assert.True(Right == quiz.RightOrWrong1 && Right == quiz.RightOrWrong2 && Right == quiz.RightOrWrong3 && 
                Right == quiz.RightOrWrong4);
        }
        [Fact]
        public void WrongAnswerTest()
        {
            const string Wrong = "Wrong";
            var quiz = new QuizVM()
            {
                UserAnswer1 = "Ben Kenobo",
                UserAnswer2 = "Tatooinp",
                UserAnswer3 = "Ben Sol",
                UserAnswer4 = "Carbonitn"
            };

            quiz.CheckAnswers();

            Assert.True(Wrong == quiz.RightOrWrong1 && Wrong == quiz.RightOrWrong2 && Wrong == quiz.RightOrWrong3 &&
                Wrong == quiz.RightOrWrong4);
        }
    }
}
