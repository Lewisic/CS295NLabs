namespace IsaacLewisSite.Models
{
    public class QuizVM
    {
        public string UserAnswer1 { get; set; }
        public string RightOrWrong1 { get; set; }
        public string UserAnswer2 { get; set; }
        public string RightOrWrong2 { get; set; }
        public string UserAnswer3 { get; set; }
        public string RightOrWrong3 { get; set; }
        public string UserAnswer4 { get; set; }
        public string RightOrWrong4 { get; set; }

        public void CheckAnswers()
        {
            RightOrWrong1 = UserAnswer1.ToLower() == "ben kenobi" ? "Right" : "Wrong";
            RightOrWrong2 = UserAnswer2.ToLower() == "tatooine" ? "Right" : "Wrong";
            RightOrWrong3 = UserAnswer3.ToLower() == "ben solo" ? "Right" : "Wrong";
            RightOrWrong4 = UserAnswer4.ToLower() == "carbonite" ? "Right" : "Wrong";
        }
    }
}
