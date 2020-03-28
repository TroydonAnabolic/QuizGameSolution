using QuizGame.AllQuizzes.MiscellaneousQuizzes;
using QuizGame.ProgrammingQuizzes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Engines
{
    public class PlayGameMethods
    {
        // when adding to this list, always enter item just before EXIT element
        public static readonly IList<string> gameList = new List<string> { "HTML", "CSS", "JAVASCRIPT", "C#", "ASP.NET", "SQL", "NETWORKING", "GENERAL", "EXIT" }.AsReadOnly();
        public static string selectGame = string.Empty;


        public void PlayGame(CSharpQuestionAndAnswer argCsharp, GeneralKnowledge argGeneralKnowledge, CalculationEngine calculation)
        {

            bool exitToMenu = false;
            do
            {
                Console.WriteLine($"Select the game you wish to play: " +
                    $"{gameList[0]} {gameList[1]} {gameList[2]} {gameList[3]} {gameList[4]} {gameList[5]} {gameList[6]} {gameList[7]}. Type {gameList[8]} to return to main menu");
                selectGame = Console.ReadLine() ?? string.Empty;

                switch (selectGame.ToUpper())
                {
                    case "HTML":
                        Console.WriteLine($"{Constants.horizontalRule}Welcome to the {gameList[0]} Game!");
                        break;
                    case "CSS":
                        Console.WriteLine($"{Constants.horizontalRule}Welcome to the {gameList[1]} Game!");
                        break;
                    case "JAVASCRIPT":
                        Console.WriteLine($"{Constants.horizontalRule}Welcome to the {gameList[2]} Game!");
                        break;
                    case "C#":
                        Console.WriteLine($"{Constants.horizontalRule}Welcome to the {gameList[3]} Game!");
                        PlayCsharpGame(argCsharp, calculation);
                        break;
                    case "ASP.NET":
                        Console.WriteLine($"{Constants.horizontalRule}Welcome to the {gameList[4]} Game!");
                        break;
                    case "SQL":
                        Console.WriteLine($"{Constants.horizontalRule}Welcome to the {gameList[5]} Game!");
                        break;
                    case "NETWORKING":
                        Console.WriteLine($"{Constants.horizontalRule}Welcome to the {gameList[6]} Game!");
                        break;
                    case "GENERAL":
                        Console.WriteLine($"{Constants.horizontalRule}Welcome to the {gameList[7]}  Game!");
                        PlayGeneralKnowledgeGame(argGeneralKnowledge, calculation);
                        break;
                    case "EXIT":
                        Console.WriteLine($"{Constants.horizontalRule}Exited Game!");
                        exitToMenu = true;
                        break;
                    default:
                        Console.WriteLine($"{Constants.horizontalRule}Cannot find game with that name, please check it is on the list, and is spelt correctly");
                        break;
                }

            } while (!exitToMenu);
        }

        public static void PlayCsharpGame(CSharpQuestionAndAnswer argCsharp, CalculationEngine calculation)
        {
            // apply C# calculations
            calculation.CalculateScore(argCsharp.questionsList, argCsharp.answerListCorrect,
                argCsharp.answerListIncorrect1, argCsharp.answerListIncorrect2, argCsharp.answerListIncorrect3);
        }

        public static void PlayGeneralKnowledgeGame(GeneralKnowledge argGeneralKnowledge, CalculationEngine calculation)
        {
            // apply C# calculations
            calculation.CalculateScore(argGeneralKnowledge.questionsList, argGeneralKnowledge.answerListCorrect,
                argGeneralKnowledge.answerListIncorrect1, argGeneralKnowledge.answerListIncorrect2, argGeneralKnowledge.answerListIncorrect3);
        }
    }
}
