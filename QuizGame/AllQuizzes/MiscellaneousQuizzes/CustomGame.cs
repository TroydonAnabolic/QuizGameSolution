using System;
using System.Collections.Generic;
using System.IO;

namespace QuizGame.AllQuizzes.MiscellaneousQuizzes
{
    public class CustomGame
    {
        public List<string> questionsList = new List<string>();
        public List<string> answerListCorrect = new List<string>();
        public List<string> answerListIncorrect1 = new List<string>();
        public List<string> answerListIncorrect2 = new List<string>();
        public List<string> answerListIncorrect3 = new List<string>();
        public void SaveSampleFile()
        {
            try
            {
                // Save sample file to the users comp (5 groups)
                Console.WriteLine("Would you like to save in a custom location or a default location? Enter 'D' if you want to use the default: C:\\Users\\[User]\\QuizFolder\\[QuizSample.txt]" +
                    "otherwise please write in the file path, in the same format as the sample above");

                string savePath = string.Empty;

                string[] lines =
                    {
                        "Question List",
                        "This is our first question",
                        "This is our second question",
                        "This is our third question",
                        "Correct Answer List",
                        "This is the first correct answer",
                        "This is the second correct answer",
                        "This is the third correct answer",
                        "Incorrect Answer List 1 (do not add what is in this bracket - has the be the answers that make the second most sense so it can remain when the user selects hint",
                        "This is the first incorrect answer",
                        "This is the second incorrect answer",
                        "This is the third incorrect answer",
                        "Incorrect Answer List 2",
                        "This is the first incorrect answer",
                        "This is the second incorrect answer",
                        "This is the third incorrect answer",
                        "Incorrect Answer List 3",
                        "This is the first incorrect answer",
                        "This is the second incorrect answer",
                        "This is the third incorrect answer",

                        "Alternatively your file can seperate each content you want to seperate with empty lines as below:","",
                       "","Question List",
                       "","This is our first question",
                       "","This is our second question",
                       "","This is our third question",
                       "","Correct Answer List",
                       "","This is the first correct answer",
                       "","This is the second correct answer",
                       "","This is the third correct answer",
                       "","Incorrect Answer List 1 (do not add what is in this bracket - has the be the answers that make the second most sense so it can remain when the user selects hint",
                       "","This is the first incorrect answer",
                       "","This is the second incorrect answer",
                       "","This is the third incorrect answer",
                       "","Incorrect Answer List 2",
                       "","This is the first incorrect answer",
                       "","This is the second incorrect answer",
                       "","This is the third incorrect answer",
                       "","Incorrect Answer List 3",
                       "","This is the first incorrect answer",
                       "","This is the second incorrect answer",
                       "","This is the third incorrect answer",
                    };

                //string defaultSavePath = $@"C:\Users\{Environment.UserName}\QuizFolder\QuizSample.txt";
                string path = string.Empty;

                while (!File.Exists(savePath)) // keep looping if the file does not exist
                {
                    savePath = Console.ReadLine() ?? string.Empty;
                    // Again if we select D we use default
                    if (savePath.Equals("D", StringComparison.OrdinalIgnoreCase))
                    {
                        // if we use the default save path and it exists we break out of loop
                        path = UseDefaultSaveMethod(lines);
                        if (File.Exists(path)) break;
                    }
                    // if we use a path and it exists we break
                    else if (File.Exists(savePath))
                    {
                        File.WriteAllLines(savePath, lines);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Sorry that path does not exist, please ensure you are formatting file path, and ensure the blank doc includes file name " + // TODO: Allow app to create the specified file path
                            "C:\\Users\\[User]\\QuizFolder\\[QuizSample.txt], please ensure to remove the brackets.\nAlternatively enter 'D' to use the default file storage location");
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // returns a list of everything on the file the user has sent


        public void ExecuteReadMethod()
        {
            try
            {
                string readFilePath = string.Empty;

                // TODO: Implement method to add a new item to the array after every space not every line incase of large paragraphs, give option to select option with space or option no space
                do
                {
                    Console.WriteLine("Please supply the file path for the questions and answers you wish to use: Remember to use the proper formatting method for file path");
                    readFilePath = Console.ReadLine() ?? string.Empty;
                    // if (File.Exists(readFilePath)) break;
                } while (!File.Exists(readFilePath));


                // store all lines into an array and make it into a list
                string[] fileContents = File.ReadAllLines(readFilePath);

                // for splits on spaces
                string fileText = File.ReadAllText(readFilePath);
                string[] splitTextOnSpace = fileText.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                List<string> contentList = new List<string>();
                string contentOptionSelected = string.Empty;

                do
                {
                    // now chose the option if we want space seperator or no spaces
                    Console.WriteLine("If you chose a file with spaces to seperate content enter 'Y' otherwise select 'N'");
                    contentOptionSelected = Console.ReadLine() ?? string.Empty;
                    // if we selected Y then we use the 
                    if (contentOptionSelected.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        foreach (var item in splitTextOnSpace)
                        {
                            contentList.Add(item);
                        }
                    }
                    else if (contentOptionSelected.Equals("N", StringComparison.OrdinalIgnoreCase))

                    {
                        foreach (var item in fileContents)
                        {
                            contentList.Add(item);
                        }
                    }
                    else Console.WriteLine("Invalid response, select Y or N");

                    if ((contentOptionSelected.Equals("Y", StringComparison.OrdinalIgnoreCase)) || (contentOptionSelected.Equals("N", StringComparison.OrdinalIgnoreCase))) break;

                } while (NotYesOrNO(contentOptionSelected));

                questionsList = new List<string>();
                answerListCorrect = new List<string>();
                answerListIncorrect1 = new List<string>();
                answerListIncorrect2 = new List<string>();
                answerListIncorrect3 = new List<string>();

                // take the list and now we can break it down into compartments
                for (int i = 0; i < contentList.Count; i++)
                {
                    // we add to the corresponding list depending on the indexes it falls between TODO: check if we leave questions null for some, and implement fix if possible
                    if (i >= 1 && i < contentList.IndexOf("Correct Answer List"))
                    {
                        questionsList.Add(contentList[i]);
                    }
                    else if (i > contentList.IndexOf("Correct Answer List") && i < contentList.IndexOf("Incorrect Answer List 1"))
                    {

                        answerListCorrect.Add(contentList[i]);
                    }
                    else if (i > contentList.IndexOf("Incorrect Answer List 1") && i < contentList.IndexOf("Incorrect Answer List 2"))
                    {
                        answerListIncorrect1.Add(contentList[i]);
                    }
                    else if (i > contentList.IndexOf("Incorrect Answer List 2") && i < contentList.IndexOf("Incorrect Answer List 3"))
                    {
                        answerListIncorrect2.Add(contentList[i]);
                    }
                    else if (i > contentList.IndexOf("Incorrect Answer List 3") && i < contentList.Count)
                    {
                        answerListIncorrect3.Add(contentList[i]);
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool NotYesOrNO(string contentOptionSelected)
        {
            return !(contentOptionSelected.Equals("Y", StringComparison.OrdinalIgnoreCase)) || !(contentOptionSelected.Equals("N", StringComparison.OrdinalIgnoreCase));
        }

        private static string UseDefaultSaveMethod(string[] lines)
        {
            string path = $@"C:\Users\Public\Public Documents\QuizFolder";
            // Try to create the directory.
            Directory.CreateDirectory(path);
            string fileName = "QuizSample.txt";
            // Use Combine again to add the file name to the path.
            path = Path.Combine(path, fileName);

            Console.WriteLine("File created, you can find the path to the sample file: {0}\n", path);


            if (!File.Exists(path))
            {

                File.WriteAllLines(path, lines);
            }
            else
            {
                Console.WriteLine("File \"{0}\" already exists.", fileName);
            }

            return path;
        }
    }
}
