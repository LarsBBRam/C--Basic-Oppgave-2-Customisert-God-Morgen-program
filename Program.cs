using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace C__Basic_Oppgave_2_Customisert_God_Morgen_program;

class Program
{
    static void Main(string[] args)
    {
        /*
        Pseudo:

        menu med options
        brukerinput må renses.

        brukerinput would be what kind of greeting they would like 
        to generate. 

        Three options:
        1. based on the current time.
        2. choose from a list of suitable ones for times of day.
        3. Add a new greeting to that time of day (requires password)
        4. Exit program.

        nr 1

        Make a random number generator and 
        generate the greeting based on the number?
        the length of the number gen must be the length
        of the list it's referring to, otherwise the 
        generator will never add the added greetings 
        the the random one.
        
        Greetings generator
        if morning say good morning equivalent
        if afternnon say good afternoon equivalent
        if night say you're up late  equivalent
        if evening say good evening equivalent
        if none of those say good day  equivalent
        

        nr 2:
        new menu.
        1 menu option for each 

        lists all the random options for each given time of day

        no exit option, only back.

        nr 3:
        Password check (easy ifelse)

        New menu.
        choose time of day to add greeting to
        read input and accept any. 
        Add input to fitting list
        back to main menu.

        */
        Random random = new();


        List<string> morningGreetings = new()
        {
            "Good morning",
            "Top of the morning to your",
            "Rise and Shine",
            "`Morning",
            "Happy morning to you"
        };
        List<string> dayGreetings = new()
        {
            "Hello",
            "Hi",
            "Hey",
            "Good to see you",
            "Yo!"
        };
        List<string> afternoonGreetings = new()
        {
            "Good afternoon",
            "`Afternoon",
            "How do you do"
        };
        List<string> eveningGreetings = new()
        {
            "Good evening",
            "Good eve",
            "`Evening",
            "I hope you're doing well this evening",
            "Hello"
        };
        List<string> nightGreetings = new()
        {
            "Hello",
            "Hi",
            "What's up",
            "How's it going"
        };

        int morningIndex = random.Next(morningGreetings.Count);
        int dayIndex = random.Next(dayGreetings.Count);
        int afternoonIndex = random.Next(afternoonGreetings.Count);
        int eveningIndex = random.Next(eveningGreetings.Count);
        int nightIndex = random.Next(nightGreetings.Count);

        Console.WriteLine(morningGreetings[morningIndex]);

        string? mainMenuInput = "";

        do
        {
            Console.Clear();
            Console.WriteLine("So, you need a greeting? Perfect, that's what this program does.");
            Console.WriteLine("Please enter what you'd like to do:");
            Console.WriteLine();
            Console.WriteLine("1. Get a greeting based on the current time of day.");
            Console.WriteLine("2. Choose a greeting from a list.");
            Console.WriteLine("3. Enter a new greeting (Admin only)");
            Console.WriteLine("4. Exit Program.");
            Console.WriteLine();
            Console.WriteLine("NB: Only enter one of these numbers.");

#pragma warning disable CS8602 //bad habit, but the warning does nothing, and is accounted for.
            mainMenuInput = Console.ReadLine().Replace(" ", "").Trim();
#pragma warning restore CS8602

            if (mainMenuInput != null && (int.TryParse(mainMenuInput, out int input)))
            {
                switch (mainMenuInput)
                {
                    case "1":
                        TimeOfDayGreeting.TimeOfDayChecker();
                        break;
                    case "2":

                        break;

                    case "3":
                    //password check.
                    //if succesfull, proceed to enter new
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Only 1, 2, 3, or 4.");
                        break;
                }
            }
        } while (mainMenuInput != "4");

    }



    public static bool TimeOfDayChecker()
    {
        int currentTime = DateTime.Now.Hour;
        bool morning;
        bool day;
        bool afternoon;
        bool evening;
        bool night;

        if (currentTime > 3 && currentTime < 11)
        {
            morning = true;
            return morning;
        }
        else if (currentTime >= 11 && currentTime < 15)
        {
            day = true;
            return day;
        }
        else if (currentTime >= 15 && currentTime < 18)
        {
            afternoon = true;
            return afternoon;
        }
        else if (currentTime >= 18 && currentTime < 22)
        {
            evening = true;
            return evening;
        }
        else
        {
            night = true;
            return night;
        }

    }

}
