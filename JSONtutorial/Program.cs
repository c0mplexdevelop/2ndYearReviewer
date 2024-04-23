using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using Reviewer;

Console.WriteLine("Welcome to the Reviewer App!");
Console.Write("Enter your desired subject code: ");
string subject = Console.ReadLine()!.ToUpper();
Console.Write($"Finals or Midterm? ");
string exam = Console.ReadLine()!.ToLower();
using FileStream jsonReader = File.OpenRead($"{subject}-{exam}.json");
QuestionClass[] questionArray = JsonSerializer.Deserialize<QuestionClass[]>(jsonReader) ?? throw new Exception("Json is empty!") ;
int score = 0;
int maxScore = questionArray!.Length;
Console.WriteLine($"""
    There are {maxScore} questions in this reviewer!@@@
    """.Replace("@", Environment.NewLine));
int turns = 0;
Random random = new Random();
random.Shuffle(questionArray);

Regex correctAnswerChoicesRegex = new(@";\s+");
Regex commaRegex = new(@",\s+");

while (turns < maxScore)
{
    QuestionClass questionClass = questionArray[turns];
    Console.WriteLine($"{turns + 1}/{maxScore}. Current Score: {score} ");
    Console.WriteLine(questionClass.Question);

    

    
    
    if (questionClass.FakeAnswers is null)
    {
        string[] allAnswers = correctAnswerChoicesRegex.IsMatch(questionClass.CorrectAnswer) ? normalizeStrings(correctAnswerChoicesRegex.Split(questionClass.CorrectAnswer)) : new string[] { };
        string userAnswer = Console.ReadLine() ?? "";
        if(commaRegex.IsMatch(userAnswer)) {
            string[] allUserAnswers = commaRegex.Split(userAnswer);
            allUserAnswers = normalizeStrings(allUserAnswers);
            foreach(var answer in allAnswers) {
                Console.WriteLine(answer);
            }

            bool isCorrect = true;
            foreach(var answer in allUserAnswers) {
                if(!allAnswers.Contains(answer.ToUpper())) {
                    Console.WriteLine($"{answer}, is not a valid answer!");
                    Console.WriteLine($"Wrong! The correct answer is: {questionClass.CorrectAnswer}; your answer is: {answer}");
                    break;
                }
            }
            if(isCorrect) {
                Console.WriteLine("Correct!");
                score++;
            }
            
            
        }
        else {
            if (userAnswer.ToLower() == questionClass.CorrectAnswer.ToLower())
            {
                score++;
                Console.WriteLine("Correct!");
            }
            else
            {
                Console.WriteLine($"Wrong! The correct answer is: {questionClass.CorrectAnswer}");
            }
        }
       

    }
    else
    {
        int currentFakeAnswerIndex = 0;
        int correctAnswerRandomIndex = random.Next(questionClass.FakeAnswers.Length);
        var correctAnswerLetter = "";
        var lettersList = new List<string> { "A", "B", "C", "D" };

        for (int idx = 0; idx < questionClass.FakeAnswers.Length + 1; idx++)
        {
            if (idx == correctAnswerRandomIndex)
            {
                Console.WriteLine($"{lettersList[idx]}. {questionClass.CorrectAnswer}");
                correctAnswerLetter = lettersList[idx];
                continue;
            }
            Console.WriteLine($"{lettersList[idx]}. {questionClass.FakeAnswers[currentFakeAnswerIndex]}");
            currentFakeAnswerIndex++;
        }

        string userAnswer = Console.ReadLine() ?? "";
        if (userAnswer.ToLower() == questionClass.CorrectAnswer.ToLower() || userAnswer.ToUpper() == correctAnswerLetter)
        {
            score++;
            Console.WriteLine("Correct!");
        }
        else
        {
            Console.WriteLine($"Wrong! The correct answer is: {questionClass.CorrectAnswer}");
        }

    }

    Console.WriteLine();
    turns++;
}

Console.WriteLine($"Your score is {score}/{maxScore}");

string[] normalizeStrings(string[] strings) {
    string[] normalizedStrings = new string[strings.Length];
    for(int idx = 0; idx < strings.Length; idx++) {
        normalizedStrings[idx] = strings[idx].ToUpper();
    }

    return normalizedStrings;
}

//string? operation = Console.ReadLine();
//if(operation == "f2c")
//{
//    double fahrenheit = Convert.ToDouble(Console.ReadLine());
//    double celcius = (5 * (fahrenheit - 32)) / 9;
//    Console.WriteLine($"Celcius: {celcius}");
//} else if(operation == "c2f")
//{
//    double celcius = Convert.ToDouble(Console.ReadLine());
//    double fahrenheit = (9 * celcius + (32 * 5)) / 5;
//    Console.WriteLine($"Imperial Fahrenheit: {fahrenheit}");
//}

//string? input = Console.ReadLine();
//int sumOfDigit = 0;
//char[] digits = input.ToCharArray();
//for(int i = 0; i < digits.Length; i++)
//{
//    sumOfDigit += (int) Char.GetNumericValue(digits[i]);
//    Console.WriteLine(sumOfDigit);
//}

//Console.WriteLine($"The sum of the digits of {input} is: {sumOfDigit}");