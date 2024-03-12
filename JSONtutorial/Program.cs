using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using Reviewer;

using FileStream jsonReader = File.OpenRead("HC101-Midterms.json");
QuestionClass[] questionArray = JsonSerializer.Deserialize<QuestionClass[]>(jsonReader) ?? throw new Exception("Json is empty!") ;
int score = 0;
int maxScore = questionArray!.Length;
Console.WriteLine($"""
    There are {maxScore} questions in this reviewer!@@@
    """.Replace("@", Environment.NewLine));
int turns = 0;
Random random = new Random();
random.Shuffle(questionArray);

while (turns < maxScore)
{
    QuestionClass questionClass = questionArray[turns];
    Console.WriteLine(questionClass.Question);
    int currentFakeAnswerIndex = 0;
    int correctAnswerRandomIndex = random.Next(questionClass.FakeAnswers.Length);
    var correctAnswerLetter = "";
    var lettersList = new List<string> { "A", "B", "C", "D" };
    if (questionClass.FakeAnswers.Length < 1)
    {

        string userAnswer = Console.ReadLine() ?? "";
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
    else
    {

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