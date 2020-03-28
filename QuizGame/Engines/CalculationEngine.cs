using System;
using System.Collections.Generic;

namespace QuizGame.Engines
{
    public class CalculationEngine
    {


        public void CalculateScore(
            List<string> argQuestions, List<string> argAnswerListCorrect, List<string> argAnswerListIncorrect1,
            List<string> argAnswerListIncorrect2, List<string> argAnswerListIncorrect3
            )
        {
            try
            {
                Random rnd = new Random();
                int correctOption = 0, mySelectedOption = 0, selectIndicator = 0;
                double score = 0, percentage = 0;
                string face = string.Empty, grade = string.Empty;
                bool isEmptyAnswer = false;
                // TODO: implement timer feature

                List<int> randomListForQuestions = new List<int>(); // create empty  list
                GenerateRandomNumberList(randomListForQuestions, argQuestions.Count); // fill list with random numbers based on size of questions array


                for (int i = 0; i < argQuestions.Count; i++)
                {
                    Console.WriteLine($"Question {i + 1}: {argQuestions[randomListForQuestions[i]]}"); // ask a question using the instance of the random list of numbers as the indexer
                    Console.WriteLine("Enter '000' at any time to exit to the game selection menu");

                    // creates a list which will be possibly shuffled for each instance, so the answers location is constantly different so the user cannot pickup the pattern
                    List<string> possibleAnswers = new List<string>() { argAnswerListCorrect[randomListForQuestions[i]], argAnswerListIncorrect1[randomListForQuestions[i]],
                        argAnswerListIncorrect2[randomListForQuestions[i]], argAnswerListIncorrect3[randomListForQuestions[i]] };

                    // Creates a list of 4 random numbers in each instance of the questions list
                    List<int> randomList = new List<int>();
                    // after we have a random list of numbers 1-4, we use it to apply a random index between 1 and 4 to the list of possible answers 
                    GenerateRandomNumberList(randomList);
                    // we randomize the index for each of the elements in possible answers

                    for (int k = 0; k < randomList.Count; k++)
                    {
                        // depending on the instance random value of k, we assign that random instance as the index of possible answers, and write that as a possible answer
                        switch (k)
                        {
                            case 0:
                                // print out proposed answer
                                Console.WriteLine($"\nOption 1: {possibleAnswers[randomList[0]]}\n");
                                // if this instance is the correct answer then assign it correctOption with the corresponding value
                                selectIndicator = 1;
                                if (possibleAnswers[randomList[0]].Equals(argAnswerListCorrect[randomListForQuestions[i]])) correctOption = 1;
                                // if not the correct answer and is null, we assign it as an empty answer
                                else if (possibleAnswers[randomList[0]].Equals(string.Empty)) isEmptyAnswer = true;
                                break;
                            case 1:
                                Console.WriteLine($"Option 2: {possibleAnswers[randomList[1]]}\n");
                                selectIndicator = 2;

                                if (possibleAnswers[randomList[1]].Equals(argAnswerListCorrect[randomListForQuestions[i]])) correctOption = 2;
                                else if (possibleAnswers[randomList[1]].Equals(string.Empty)) isEmptyAnswer = true;

                                break;
                            case 2:
                                Console.WriteLine($"Option 3: {possibleAnswers[randomList[2]]}\n");
                                selectIndicator = 3;

                                if (possibleAnswers[randomList[2]].Equals(argAnswerListCorrect[randomListForQuestions[i]])) correctOption = 3;
                                else if (possibleAnswers[randomList[2]].Equals(string.Empty)) isEmptyAnswer = true;

                                break;
                            case 3:
                                Console.WriteLine($"Option 4: {possibleAnswers[randomList[3]]}\n");
                                selectIndicator = 4;

                                if (possibleAnswers[randomList[3]].Equals(argAnswerListCorrect[randomListForQuestions[i]])) correctOption = 4;
                                else if (possibleAnswers[randomList[3]].Equals(string.Empty)) isEmptyAnswer = true;

                                break;
                        }
                    }
                    // TODO: Extract method for scoring calculation
                    Console.WriteLine("\nWhich Option is correct?\n\nEnter '9' if you are stuck, you will lose 0.5 points\n");

                    // if possible answer is the correct one then we will increase the score
                    mySelectedOption = ConvertToInteger(Console.ReadLine() ?? string.Empty);
                    // each time i select the correct option I am increasing the score
                    if (mySelectedOption == correctOption)
                    {
                        score++;
                        Console.WriteLine($"{Constants.horizontalRule}Correct! Your current Score is: {score} out of {argQuestions.Count}{Constants.horizontalRule}");
                    }

                    // if its not the correct option but one of the other options available, incorrect option can only have the values that correct option does not and can only be 1 2 3 or 4
                    else if (AnswerOptions(mySelectedOption))
                    {
                        if (isEmptyAnswer)
                        {
                            Console.WriteLine($"Sorry the answer you selected currently has no value, please select one of the current valid options: " +
                                // using ?? to decide which items to display on the console
                                $"{possibleAnswers[randomList[0]]} {possibleAnswers[randomList[1]]} {possibleAnswers[randomList[3]]} {possibleAnswers[randomList[4]]}");
                            i--; // go back to some quetion
                            continue;
                        }
                        else
                            Console.WriteLine($"{Constants.horizontalRule}Sorry that is incorrect, your current score is: {score} out of {argQuestions.Count}{Constants.horizontalRule}");
                    }
                    // if the user enters 9, we empty the string value for 2 of the questions and only leave 2 answers
                    else if (mySelectedOption == 9)
                    {
                        argAnswerListIncorrect2[randomListForQuestions[i]] = string.Empty;
                        argAnswerListIncorrect3[randomListForQuestions[i]] = string.Empty;
                        score = score - 0.5;
                        i--;
                        Console.WriteLine($"\nTwo options have been removed to make it easier, your score is now: {score}\n");
                        continue;
                    }
                    else if (mySelectedOption == 000)
                    {
                        i = argQuestions.Count;
                        Console.WriteLine($"You have exited from the {PlayGameMethods.selectGame.ToUpper()} game");
                    }
                    // if we have an empty answer, and it is any one of the selectd options
                    //else if (AnswerOptions(mySelectedOption) && isEmptyAnswer)
                    //{

                    //}
                    else
                    {
                        Console.WriteLine("Sorry that is an invalid option, please select a number between 1 2 3 4, if you are unsure, select 9 for a hint, you will loose 0.5 points\n");
                        i--;
                        continue;
                    }
                    // if a user selects
                }
                percentage = score / argQuestions.Count * 100;
                if (percentage > 90) face = ":))";
                else if (percentage > 50) face = ":)";
                else face = ":(";

                if (percentage >= 96.50) grade = "A+";
                else if (percentage < 96.50 && percentage >= 92.5) grade = "A";
                else if (percentage < 92.5 && percentage >= 89.5) grade = "A-";
                else if (percentage < 89.5 && percentage >= 86.5) grade = "B+";
                else if (percentage < 86.5 && percentage >= 82.5) grade = "B";
                else if (percentage < 82.5 && percentage >= 79.5) grade = "B-";
                else if (percentage < 79.5 && percentage >= 76.5) grade = "C+";
                else if (percentage < 76.5 && percentage >= 72.5) grade = "C";
                else if (percentage < 72.5 && percentage >= 69.5) grade = "C-";
                else if (percentage < 69.5 && percentage >= 66.5) grade = "D+";
                else if (percentage < 66.5 && percentage >= 62.5) grade = "D";
                else if (percentage < 62.5 && percentage >= 59.5) grade = "D-";
                else if (percentage < 59.5) grade = "F";

                // if we did not manually exit the game do not print the game over option
                if (mySelectedOption != 000)
                {
                    Console.WriteLine($"{Constants.horizontalRule}{Constants.horizontalRule}" +
                        $"Game Over! Your final Score is: {score} out of {argQuestions.Count}! Your achieved a mark of {percentage}%, Your Grade is: {grade} {face}" +
                        $"{Constants.horizontalRule}{Constants.horizontalRule}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static bool AnswerOptions(int mySelectedOption)
        {
            return mySelectedOption == 1 || mySelectedOption == 2 || mySelectedOption == 3 || mySelectedOption == 4;
        }

        // Create a list of 4 random numbers method
        public static List<int> GenerateRandomNumberList(List<int> argRandList)
        {
            Random a = new Random();
            int myNumber = 0;

            while (argRandList.Count < 5) // keep adding numbers to the list until we have 4 numbers in the list
            {

                myNumber = a.Next(0, 4);
                if (!argRandList.Contains(myNumber))
                    argRandList.Add(myNumber);
                if (argRandList.Count == 4) break;
            }
            return argRandList;
        }

        // Override Random number generator to shuffle the questions order based on number of questions
        public static List<int> GenerateRandomNumberList(List<int> argRandList, int argNumberOfQuestions)
        {
            try
            {
                Random a = new Random();
                int myNumber = 0;

                while (argRandList.Count < argNumberOfQuestions + 1) // keep adding numbers to the list until we have the total number of questions assigned random indexes
                {

                    myNumber = a.Next(0, argNumberOfQuestions);
                    if (!argRandList.Contains(myNumber))
                        argRandList.Add(myNumber);
                    if (argRandList.Count == argNumberOfQuestions) break;
                }
                return argRandList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // fast custom method to convert a string to an integer
        public static int ConvertToInteger(string argStringToConvert)
        {
            try
            {
                var temp = 0;
                for (int i = 0; i < argStringToConvert.Length; i++)
                    temp = temp * 10 + (argStringToConvert[i] - '0');
                return temp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
