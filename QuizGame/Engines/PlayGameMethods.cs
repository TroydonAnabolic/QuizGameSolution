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
        public static readonly IList<string> gameList = new List<string> { "HTML", "CSS", "JAVASCRIPT", "C#", "ASP.NET", "SQL", "NETWORKING", "GENERAL", "FILE", "EXIT" }.AsReadOnly();
        public static string selectGame = string.Empty;


        public void PlayGame(CSharpQuestionAndAnswer argCsharp, GeneralKnowledge argGeneralKnowledge, CustomGame argCustomGame, CalculationEngine argCalculation)
        {
            // TODO: Implement option to select a filePath for a txt file of the user, then use readLines, read all paragraphs separated by title of paragraph,
            //logic should be if a line contains("Question List")("CorrectAnswer List") etc. then ignore that line. Count the number of lines then divide it by 5 and minus 5 to exclude titles.
            //Also generate a file output to save to the users computer to show setup style sample
            bool exitToMenu = false;
            do 
            {
                Console.WriteLine($"Select the game you wish to play: " +
                    $"{gameList[0]} {gameList[1]} {gameList[2]} {gameList[3]} {gameList[4]} {gameList[5]} {gameList[6]} {gameList[7]} {gameList[8]}. Type {gameList[9]} to return to main menu");
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
                        PlayCsharpGame(argCsharp, argCalculation);
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
                        PlayGeneralKnowledgeGame(argGeneralKnowledge, argCalculation);
                        break;
                    case "FILE":
                        Console.WriteLine($"{Constants.horizontalRule}Welcome to your (game name goes here)  Game!");
                        PlayCustomGame(argCustomGame, argCalculation);
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

        public static void PlayCsharpGame(CSharpQuestionAndAnswer argCsharp, CalculationEngine argCalculation)
        {
            // apply C# argCalculations
            argCalculation.CalculateScore(argCsharp.questionsList, argCsharp.answerListCorrect,
                argCsharp.answerListIncorrect1, argCsharp.answerListIncorrect2, argCsharp.answerListIncorrect3);
        }

        public static void PlayGeneralKnowledgeGame(GeneralKnowledge argGeneralKnowledge, CalculationEngine argCalculation)
        {
            argCalculation.CalculateScore(argGeneralKnowledge.questionsList, argGeneralKnowledge.answerListCorrect,
                argGeneralKnowledge.answerListIncorrect1, argGeneralKnowledge.answerListIncorrect2, argGeneralKnowledge.answerListIncorrect3);
        }
        public static void PlayCustomGame(CustomGame argCustomGame, CalculationEngine argCalculation)
        {
            //apply C# argCalculations
            argCustomGame.SaveSampleFile();
            //argCalculation.CalculateScore(argCustomGame.questionsList, argCustomGame.answerListCorrect,
            //    argCustomGame.answerListIncorrect1, argCustomGame.answerListIncorrect2, argCustomGame.answerListIncorrect3);
        }
    }
}
