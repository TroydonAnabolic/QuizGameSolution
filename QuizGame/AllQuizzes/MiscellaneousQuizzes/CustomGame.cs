using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QuizGame.AllQuizzes.MiscellaneousQuizzes
{
    public class CustomGame
    {
        public void SaveSampleFile()
        {
            try
            {
                // Save sample file to the users comp (5 groups)
                Console.WriteLine("Would you like to save in a custom location or a default location? Enter 'D' if you want to use the default: C:\\Users\\User\\QuizFolder\\QuizSample.txt" +
                    "otherwise please write in the file path, in the same format as the sample above");

                string savePath = Console.ReadLine() ?? string.Empty;

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
                        "Incorrect Answer List 1, List(has the be the answers that make the second most sense so it can remain when the user selects hint",
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
                    };

                string defaultSavePath = $@"C:\Users\{Environment.UserName}\QuizFolder\QuizSample.txt";
                string path = string.Empty;




                // If we choose default then we save in default path
                if (savePath.Equals("D", StringComparison.OrdinalIgnoreCase))
                {
                  
                        //  string user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                        do
                        {

                        // Check that the file doesn't already exist. If it doesn't exist, create
                        // the file and write integers 0 - 99 to it.
                        // DANGER: System.IO.File.Create will overwrite the file if it already exists.
                        // This could happen even with random file names, although it is unlikely.
                        // Specify the directory you want to manipulate.
                        String UserName = Application.GetNamespace("MAPI").CurrentUser.Name;

                        path = $@"C:\Users\Public\Public Documents\QuizFolder";
                        // Try to create the directory.
                        Directory.CreateDirectory(path);
                        string fileName = "QuizSample.txt";
                        // Use Combine again to add the file name to the path.
                         path = Path.Combine(path, fileName);

                        Console.WriteLine("Path to my file: {0}\n", path);


                        if (!File.Exists(path))
                            {

                                File.WriteAllLines(path, lines);
                            }
                            else
                            {
                                Console.WriteLine("File \"{0}\" already exists.", fileName);
                                return;
                            }

                        } while (!File.Exists(path)); // keep looping until the file path exists
                    }

                // Otherwise use the written file path
                else
                {
                    while (!File.Exists(savePath)) // keep looping if the file does not exist
                    {
                        Console.WriteLine("Sorry that path does not exist, please ensure you are formatting file path as the sample above");
                        savePath = Console.ReadLine() ?? string.Empty;
                    }
                    // once we have a valid path we save it
                    File.WriteAllLines(savePath, lines);
                }

        }


            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ReadQuizFile(string argFileReadPath)
        {

        }

    }
}
