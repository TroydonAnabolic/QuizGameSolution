using System.Collections.Generic;

namespace QuizGame.ProgrammingQuizzes
{
    public class CSharpQuestionAndAnswer
    {
        public List<string> questionsList = new List<string>
        {
            "What is C#?",
            "What is type-safe?",
            "What is a managed language?",
            "What is Intermediate Language?",
            "What is the Big-O Notation?",
            "What are the three types of comments in C#?",
            "Can multiple catch blocks be executed?",
            "What is the difference between public, statc, and void?",
            "What is an object",
            "Define constructors.",
            //"Define destructors",
        };

        public List<string> answerListCorrect = new List<string>
        {
            "C# is an object oriented, type safe, and managed language that is compiled by .NET framework to generate Microsoft Intermediate Language.", // 
            "Type-safe is when the compiler throws an error if you try to assign the wrong type to a variable e.g 'int x = 5; x = 'test';' this will fail because we are assigning a alphabetic string to" +
            " type int", //
            "A managed language, is when the CLR(Common Language Runtime) that manages execution of .NET programs, is managed by the GC(Garbage Collector). This includes error handling, memory management etc, " +
            "instead of being handled by the OS(Operation System). You will get Intermediate Language code when the program compiles.", //
            "Intermediate language is a language read by the compiler, and is a product of high level language compilation. Once done it is then optimizes, then translated to machine code(assembly).", //
            "Big O notation is used in Computer Science to describe the performance or complexity of an algorithm. Big O specifically describes the worst-case scenario, and can be used to describe the " +
            "execution time required or the space used (e.g. in memory or on disk) by an algorithm.", //
            "The three times of comments are single line comment: //, multiline comment: /* */, XML comment: ///.", //
            "No multiple catch bocks can't be executed. Omce the proper catch code executed, the control is transferred to the finally block, and then the code that follows the finally block executed.", //
            "Public declared variables or methods are accessible anywhere in the application. Static declared variables or methods are globally accessible without creating an instance of the class. Static" +
            "member are by default not globally accessible it depends on the type of access modifier used. The compiler stores the address of the method as the entry point and uses this information to begin" +
            "execution before any objects are created. And Void is a type modifier that states that the method or variable does not return any value.", //
            "An object is an instance of a class through which we access the methods of that class. 'New' keyword is used to create an object. A class that creates an object in memory will contain the" +
            "information about the methods, variables, and behaviour of that class.", //
            "A constructor is a member function in a class that has the same name as its class. The constructor is automatically invoked whenever an object of a class is created. It constructs the values of " +
            "data members while initializing the class.", //
        };

        public List<string> answerListIncorrect1 = new List<string>
        {
            "C# is an procedural programming, type safe, and non-managed language that is compiled by .NET framework to generate Microsoft Intermediate Language.", //
            "Type-safe is when the compiler throws an warning if you try to assign the wrong type to a variable e.g var x = 5; x = 10;' this will fail because we are assigning are assigning a numerical value" +
            " without declaring as an  int", //
            "A managed language, is when the CLR(Common Language Runtime) that manages execution of .NET programs, is managed by the OS. This includes error handling memory management  etc, " +
            "instead of being handled by a GC (Garbage Collector).", //
            "Intermediate language is a language read by the OS, and is a product of high level language compilation. Once done it is then optimizes, then translated to machine code(assembly).", //
            "Big O notation is used in Computer Science to describe the power of an application. Big O specifically determines how much RAM a computer can store", //
            "The three times of comments are single line comment: --, multiline comment: /* */, XML comment: ---.", //
            "No multiple catch bocks can't be executed. Omce the proper catch code executed, the control is transferred back to the try block, and then continues from the line after where the error ocurred.", //
            "Public declared variables or methods are accessible anywhere within a class. Static declared variables or methods are globally accessible and still require an object of the class to be instantiated." +
            " Static member are by default  globally accessible regardless of the type of access modifier used. The compiler stores the address of the method as the entry point and uses this information to begin" +
            "execution immediately after objects are created. And Void is a type modifier that states that the method or variable does not return any value.", //
            "An object are used to instantiate classes. 'New' keyword is used to create a class from the object. A object that creates a class in memory will contain the" +
            "information about the methods, variables, and behaviour of that object.", //
             "A constructor is a member function in a struct that has the same name as its struct. The constructor is automatically invoked whenever an object of a struct is created. It constructs the values of " +
            "data members while initializing the struct.", //
        };

        // make this list the list that remains when hint is activated
        public List<string> answerListIncorrect2 = new List<string>
        {
            "C# is an object oriented, type safe, and unmanaged language that is directly executed by OS, and is compiled by .NET framework to generate Microsoft Intermediate Language.", //
            "Type-safe is when the OS throws an error if you try to assign the wrong type to a variable e.g 'int x = 5; x = 'test';' this will fail because we are assigning a alphabetic string to type int", //
            "A managed language, is when the language is being managed by a specific individual", //
            "Intermediate language is a language read by the compiler, and is a product of low level language compilation. Once done it is then optimizes, then translated to machine code(assembly).", //
            "Big O notation is used in Computer Science to describe the level of a language, which can be a high level language or a low level language that directly communicates with the OS ", //
            "The three times of comments are single line comment: @**@, multiline comment: /* */, XML comment: ///.", //
            "Yes multiple catch bocks can be executed. Every catch block that meet their catch condition will fire off, the control is transferred to the finally block, and then the code that follows " +
            "the finally block executed.", //
            "Public declared variables or methods are accessible anywhere in the application. Static declared variables or methods are not globally accessible. Static" +
            "member are by default not globally accessible. Access modifiers cannot deter the accessibility of static variabels and methods The compiler stores the address of the method as the entry" +
            " point and uses this information to begin execution before any objects are created. And Void is a type modifier that states that the method or variable does not return any value.", //
            "An object is an instance of a class through which we access the methods of that class. 'New' keyword is used to create an object. A class that creates an object in memory will contain the" +
            "information about the methods, variables, and behaviour of that class. We can only create one object from each class.", //
             "A constructor is a member function in a class that cannot have the same name as its class. The constructor is automatically invoked whenever an object of a class is created. It constructs" +
            " the values of data members while initializing the class.", //
        };

        public List<string> answerListIncorrect3 = new List<string>
        {
            "C# is a markup, type safe, and managed language that is compiled by .NET framework to generate Microsoft Intermediate Language.", //
            "Type-safe means a design pattern that implements safe practices when typing up variables.", //
            "A managed language, is when the CLR(Common Language Runtime) that manages execution of .NET programs, is managed by the GC(Garbage Collector). This includes error handling  etc but exludes " +
            "memory management instead of being handled by the OS(Operation System). You get machine code when the program compiles.", //
            "Intermediate language is a language read by the compiler, and is a product of low level language compilation. Once done it is then optimizes, then translated to high level code.", //
            "Big O notation is used in Computer Science to describe the performance or complexity of an algorithm. Big O specifically describes the best-case scenario, and can be used to describe and measure" +
            "the amount of data being processed using algorithms.", //
            "The three times of comments are single line comment: //, multiline comment: ///, XML comment: /**/.", //
            "Yes multiple catch bocks can be executed. It depends on the situation, you can specify on the catch block where to leave the control, once specified code from the catch block is executed, control" +
            " is transferred to the finally block, and then the code that follows the finally block executed.", //
            "Public declared variables or methods are accessible anywhere in the application. Static declared variables or methods are globally accessible without creating an instance of the class. Static" +
            "member are constants and their values cannot be modified. The compiler stores the address of the method as the entry point and uses this information to begin" +
            "execution before any objects are created. And Void is a type modifier that states that the method or variable does not return any value.", //
            "An object is an instance of a class through which we access the methods of that class. 'New' keyword is used to create an object. A class that creates an object in memory will not contain the" +
            "information about the methods, variables, and behaviour of that class. We will require to define this during instantiation.", //
            "A constructor is a member function in a class that has the same name as its class. The constructor is automatically invoked whenever a method is run. It constructs the values of " +
            "data members while initializing the class.", //
        };

    }
}
