using QuizGame.AllQuizzes.MiscellaneousQuizzes;
using QuizGame.ProgrammingQuizzes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Engines
{
    public class PlayGameMethods
    {
        // when adding to this list, always enter item just before EXIT element
        public static string selectGame = string.Empty;

        public void PlayGame(CSharpQuestionAndAnswer argCsharp, GeneralKnowledge argGeneralKnowledge, CustomGame argCustomGame, CalculationEngine argCalculation)
        {
            bool exitToMenu = false, customSelected = false;
            string selectCustomOrBuiltIn = string.Empty;
            IList<string> gameList = new List<string> { "HTML", "CSS", "JAVASCRIPT", "C#", "ASP.NET", "SQL", "NETWORKING", "GENERAL", "EXIT" };


            do
            {
                selectCustomOrBuiltIn = ChooseCustomOrBuiltIn(gameList, ref customSelected);

                Console.WriteLine($"Select the game you wish to play: " +
                    $"{gameList[0]}, {gameList[1]}, {gameList[2]}, {gameList[3]}, {gameList[4]}, {gameList[5]}, {gameList[6]}, {gameList[7]}," +
                    $" MYGAME to select {gameList[gameList.Count - 1]}, if you created one." + // last element will be the name of the game
                    $". Type EXIT to return to main menu");
                selectGame = Console.ReadLine() ?? string.Empty;

                switch (selectGame.ToUpper())
                {
                    case "HTML":
                        Console.WriteLine($"{Constants.horizontalRule}Welcome to the {gameList[0]} Game!\n");
                        break;
                    case "CSS":
                        Console.WriteLine($"{Constants.horizontalRule}Welcome to the {gameList[1]} Game!\n");
                        break;
                    case "JAVASCRIPT":
                        Console.WriteLine($"{Constants.horizontalRule}Welcome to the {gameList[2]} Game!\n");
                        break;
                    case "C#":
                        Console.WriteLine($"{Constants.horizontalRule}Welcome to the {gameList[3]} Game!\n");
                        PlayCsharpGame(argCsharp, argCalculation);
                        break;
                    case "ASP.NET":
                        Console.WriteLine($"{Constants.horizontalRule}Welcome to the {gameList[4]} Game\n!");
                        break;
                    case "SQL":
                        Console.WriteLine($"{Constants.horizontalRule}Welcome to the {gameList[5]} Game!\n");
                        break;
                    case "NETWORKING":
                        Console.WriteLine($"{Constants.horizontalRule}Welcome to the {gameList[6]} Game!\n");
                        break;
                    case "GENERAL":
                        Console.WriteLine($"{Constants.horizontalRule}Welcome to the {gameList[7]}  Game!\n"); // custom always last
                        PlayGeneralKnowledgeGame(argGeneralKnowledge, argCalculation);
                        break;

                    case "MYGAME":
                        Console.WriteLine($"{Constants.horizontalRule}Welcome to your {gameList[gameList.Count - 1]}  Game!\n");
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

                if (customSelected) // if custom was selected we remove the custom game so we can add a new custom game, ensure we set it back to false so we do not keep removing list items
                {
                    gameList.RemoveAt(gameList.Count - 1);
                    customSelected = false;
                }

            } while (!exitToMenu);
        }

        private static string ChooseCustomOrBuiltIn(IList<string> gameList, ref bool argCustomSelected) // ref to save changes
        {
            string selectCustomOrBuiltIn;
            do
            {
                Console.WriteLine("Would you like to use add a custom game or use a default game? 'Y' for custom or 'N' for built in");
                selectCustomOrBuiltIn = Console.ReadLine() ?? string.Empty;
                // if we select to use a custom game we prompt for the game name
                if (selectCustomOrBuiltIn.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    // name game and make custom selected true
                    Console.WriteLine("Please name your game");
                    gameList.Add(Console.ReadLine() ?? string.Empty);
                    argCustomSelected = true;
                    break;
                }
                else if (selectCustomOrBuiltIn.Equals("N", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

            } while (CustomGame.NotYesOrNO(selectCustomOrBuiltIn));
            return selectCustomOrBuiltIn;
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
            PlayGameMethods playGameMethods = new PlayGameMethods();
            argCustomGame.SaveSampleFile();
            argCustomGame.ExecuteReadMethod();

            argCalculation.CalculateScore(argCustomGame.questionsList, argCustomGame.answerListCorrect,
                argCustomGame.answerListIncorrect1, argCustomGame.answerListIncorrect2, argCustomGame.answerListIncorrect3);
        }
    }
}
