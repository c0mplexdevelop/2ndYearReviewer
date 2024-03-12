using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reviewer
{
    public class QuestionClass
    {
        public string Question {  get; init; }
        public string CorrectAnswer { get; init; }
        public string[] FakeAnswers { get; init; }  
    }
}
