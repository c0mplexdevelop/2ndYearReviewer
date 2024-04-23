using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reviewer
{
    public class QuestionClass
    {
        public required string Question {  get; init; }
        public required string CorrectAnswer { get; init; }
        public string[]? FakeAnswers { get; init; }  
    }
}
