using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarSystem_GRP5.Models.ViewModels
{
    public class QuizView
    {
        private List<Quiz> quiz_list;
        private PageResources resources;
        public List<Quiz> Quiz_list { get => quiz_list; set => quiz_list = value; }
        public PageResources Resources { get => resources; set => resources = value; }

        public QuizView()
        {
            this.quiz_list = new List<Quiz>();
        }
    }
}
