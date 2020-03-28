using QuizGame.AllQuizzes.MiscellaneousQuizzes;
using QuizGame.Engines;
using QuizGame.ProgrammingQuizzes;
using System;

namespace QuizGame
{
    // TO DO: Make a WinForms version
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CalculationEngine calculation = new CalculationEngine();
                PlayGameMethods playGameMethods = new PlayGameMethods();
                CSharpQuestionAndAnswer cSharpQuestionAndAnswer = new CSharpQuestionAndAnswer();
                GeneralKnowledge generalKnowledge = new GeneralKnowledge();
                bool continueQuizGames = false;
                do
                {
                    // Decide if you want to play
                    Console.WriteLine("Do you wish to continue playing? Y/N");
                    var shouldPlay = Console.ReadLine() ?? string.Empty;

                    if (shouldPlay.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        playGameMethods.PlayGame(cSharpQuestionAndAnswer, generalKnowledge, calculation);
                        continueQuizGames = true;
                    }
                    // Immediately exit app if we do not want to continue
                    else if (shouldPlay.Equals("N", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Quiz has been closed. Press any key to continue");
                        Environment.Exit(0);
                    }
                    // If we enter an invalid input just keep playing
                    else
                    {
                        Console.WriteLine("Operation Not recognized");
                        continueQuizGames = true;
                    }
                } while (continueQuizGames);

            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error" + ex.Message);
            }
        }
    }
}
