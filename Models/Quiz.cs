using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarSystem_GRP5.Models
{
    public class Quiz
    {
        private string question;
        private string answer;
        private List<string> answers;

        public string Question { get => question; set => question = value; }
        public string Answer { get => answer; set => answer = value; }
        public List<string> Answers { get => answers; set => answers = value; }

        public Quiz()
        {
            this.answers = new List<string>();
        }
    }
}
