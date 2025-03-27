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
                        TimeOfDayChecker();
                        break;
                    case "2":
                        ListGreetingMenu();
                        break;

                    case "3":
                        PasswordChecker();
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Only 1, 2, 3, or 4.");
                        break;
                }
            }
        } while (mainMenuInput != "4");

    }

    public static void ListGreetingMenu()
    {
        string? listGreetingMenuInput;

        do
        {

            Console.Clear();
            Console.WriteLine("Please choose what time of day you want a list of greetings for.");
            Console.WriteLine();
            Console.WriteLine("1. Morning");
            Console.WriteLine("2. Day");
            Console.WriteLine("3. Afternoon");
            Console.WriteLine("4. Evening");
            Console.WriteLine("5. Night");
            Console.WriteLine("6. Go back");
            Console.WriteLine();

#pragma warning disable CS8602 //bad habit, but the warning does nothing, and is accounted for.
            listGreetingMenuInput = Console.ReadLine().Replace(" ", "").Trim();
#pragma warning restore CS8602
            if (listGreetingMenuInput != null && (int.TryParse(listGreetingMenuInput, out int input)))
            {
                switch (input.ToString())
                {
                    case "1":
                        foreach (var greeting in GreetingsLists.morningGreetings)
                        {

                            Console.WriteLine();
                            Console.WriteLine(greeting);
                        }
                        Console.WriteLine();
                        Console.WriteLine("These are the morning greetings currently stored.");
                        Console.WriteLine("Press enter to return");
                        Console.ReadLine();
                        break;

                    case "2":
                        foreach (var greeting in GreetingsLists.dayGreetings)
                        {
                            Console.WriteLine();
                            Console.WriteLine(greeting);
                        }
                        Console.WriteLine();
                        Console.WriteLine("These are the greetings suitable for daytime currently stored.");
                        Console.WriteLine("Press enter to return");
                        Console.ReadLine();
                        break;

                    case "3":
                        foreach (var greeting in GreetingsLists.afternoonGreetings)
                        {
                            Console.WriteLine();
                            Console.WriteLine(greeting);
                        }
                        Console.WriteLine();
                        Console.WriteLine("These are the afternoon greetings currently stored.");
                        Console.WriteLine("Press enter to return");
                        Console.ReadLine();
                        break;

                    case "4":

                        foreach (var greeting in GreetingsLists.eveningGreetings)
                        {
                            Console.WriteLine();
                            Console.WriteLine(greeting);
                        }

                        Console.WriteLine();
                        Console.WriteLine("These are the evening greetings currently stored.");
                        Console.WriteLine("Press enter to return");
                        Console.ReadLine();
                        break;

                    case "5":

                        foreach (var greeting in GreetingsLists.nightGreetings)
                        {
                            Console.WriteLine();
                            Console.WriteLine(greeting);
                        }
                        Console.WriteLine();
                        Console.WriteLine("These are the morning greetings currently stored.");
                        Console.WriteLine("Press enter to return");
                        Console.ReadLine();
                        break;

                }
            }
        } while (listGreetingMenuInput != "6");


    }

    public static void NewGreetingStorer()
    {

        string? listStorageMenuInput;
        do
        {
            Console.Clear();
            Console.WriteLine("In what category would you like to enter your greeting?");
            Console.WriteLine();
            Console.WriteLine("1. Morning");
            Console.WriteLine("2. Day");
            Console.WriteLine("3. Afternoon");
            Console.WriteLine("4. Evening");
            Console.WriteLine("5. Night");
            Console.WriteLine("6. Go back");
            Console.WriteLine();

#pragma warning disable CS8602 //bad habit, but the warning does nothing, and is accounted for.
            listStorageMenuInput = Console.ReadLine().Replace(" ", "").Trim();
#pragma warning restore CS8602
            if (listStorageMenuInput != null && (int.TryParse(listStorageMenuInput, out int input)))
            {
                switch (input.ToString())
                {
                    case "1":
                        Console.WriteLine("Please enter your new morning greeting.");
                        string? morningInput = Console.ReadLine();
                        if (morningInput != null)
                        {
                            GreetingsLists.morningGreetings.Add(morningInput);
                            Console.WriteLine($"'{morningInput}' was added to the morning greetings. Press enter to return to return to the previous menu.");
                            Console.ReadLine();
                        }
                        break;
                    case "2":
                        Console.WriteLine("Please enter your new day greeting.");
                        string? dayInput = Console.ReadLine();
                        if (dayInput != null)
                        {
                            GreetingsLists.dayGreetings.Add(dayInput);
                            Console.WriteLine($"'{dayInput}' was added to the day greetings. Press enter to return to return to the previous menu.");
                            Console.ReadLine();
                        }
                        break;
                    case "3":
                        Console.WriteLine("Please enter your new afternoon greeting.");
                        string? afternoonInput = Console.ReadLine();
                        if (afternoonInput != null)
                        {
                            GreetingsLists.afternoonGreetings.Add(afternoonInput);
                            Console.WriteLine($"'{afternoonInput}' was added to the afternoon greetings. Press enter to return to return to the previous menu.");
                            Console.ReadLine();
                        }
                        break;
                    case "4":
                        Console.WriteLine("Please enter your new evening greeting.");
                        string? eveningInput = Console.ReadLine();
                        if (eveningInput != null)
                        {
                            GreetingsLists.eveningGreetings.Add(eveningInput);
                            Console.WriteLine($"'{eveningInput}' was added to the evening greetings. Press enter to return to return to the previous menu.");
                            Console.ReadLine();
                        }
                        break;
                    case "5":
                        Console.WriteLine("Please enter your new night greeting.");
                        string? nightInput = Console.ReadLine();
                        if (nightInput != null)
                        {
                            GreetingsLists.nightGreetings.Add(nightInput);
                            Console.WriteLine($"'{nightInput}' was added to the night greetings. Press enter to return to return to the previous menu.");
                            Console.ReadLine();
                        }
                        break;
                }
            }
        } while (listStorageMenuInput != "6");
    }
    public static void PasswordChecker()
    {
        string passwordInput = "";

        Console.WriteLine("Please enter the password");

#pragma warning disable CS8602
        passwordInput = Console.ReadLine().Trim();
#pragma warning restore CS8602

        if (passwordInput != null && passwordInput == "passord")
        {
            Console.WriteLine("Password Accepted. Press enter to proceed.");
            Console.ReadLine();
            NewGreetingStorer();
        }
        else
        {
            Console.WriteLine("Incorrect password, please contact an administrator if you need access.");
            Console.WriteLine("Press enter to return.");
            Console.ReadLine();

        }
    }
    public class GreetingsLists
    {
        public static List<string> morningGreetings = new()
        {
            "Good morning",
            "Top of the morning to you",
            "Rise and Shine",
            "`Morning",
            "Happy morning to you"
        };
        public static List<string> dayGreetings = new()
        {
            "Hello",
            "Hi",
            "Hey",
            "Good to see you",
            "Yo!"
        };
        public static List<string> afternoonGreetings = new()
        {
            "Good afternoon",
            "`Afternoon",
            "How do you do"
        };
        public static List<string> eveningGreetings = new()
        {
            "Good evening",
            "Good eve",
            "`Evening",
            "I hope you're doing well this evening",
            "Hello"
        };
        public static List<string> nightGreetings = new()
        {
            "Hello",
            "Hi",
            "What's up",
            "How's it going"
        };
    }

    //This function checks the time of day, and creates a greeting from a random set of lists
    // based on the time of day found.
    public static void TimeOfDayChecker()
    {
        Random random = new();



        int morningIndex = random.Next(GreetingsLists.morningGreetings.Count);
        int dayIndex = random.Next(GreetingsLists.dayGreetings.Count);
        int afternoonIndex = random.Next(GreetingsLists.afternoonGreetings.Count);
        int eveningIndex = random.Next(GreetingsLists.eveningGreetings.Count);
        int nightIndex = random.Next(GreetingsLists.nightGreetings.Count);


        int currentTime = DateTime.Now.Hour;
        bool morning = false;
        bool day = false;
        bool afternoon = false;
        bool evening = false;
        bool night = false;

        if (currentTime > 3 && currentTime < 11)
        {
            morning = true;

        }
        else if (currentTime >= 11 && currentTime < 15)
        {
            day = true;

        }
        else if (currentTime >= 15 && currentTime < 18)
        {
            afternoon = true;

        }
        else if (currentTime >= 18 && currentTime < 22)
        {
            evening = true;

        }
        else
        {
            night = true;

        }

        if (morning)
        {
            Console.WriteLine("Your greeting is:");
            Console.WriteLine();
            Console.WriteLine(GreetingsLists.morningGreetings[morningIndex]);
            Console.WriteLine();
            Console.WriteLine("Press enter to return");
            Console.ReadLine();
        }
        else if (day)
        {
            Console.WriteLine("Your greeting is:");
            Console.WriteLine();
            Console.WriteLine(GreetingsLists.dayGreetings[dayIndex]);
            Console.WriteLine();
            Console.WriteLine("Press enter to return");
            Console.ReadLine();
        }
        else if (afternoon)
        {
            Console.WriteLine("Your greeting is:");
            Console.WriteLine();
            Console.WriteLine(GreetingsLists.afternoonGreetings[afternoonIndex]);
            Console.WriteLine();
            Console.WriteLine("Press enter to return");
            Console.ReadLine();
        }
        else if (evening)
        {
            Console.WriteLine("Your greeting is:");
            Console.WriteLine();
            Console.WriteLine(GreetingsLists.eveningGreetings[eveningIndex]);
            Console.WriteLine();
            Console.WriteLine("Press enter to return");
            Console.ReadLine();
        }
        else if (night)
        {
            Console.WriteLine("Your greeting is:");
            Console.WriteLine();
            Console.WriteLine(GreetingsLists.nightGreetings[nightIndex]);
            Console.WriteLine();
            Console.WriteLine("Press enter to return");
            Console.ReadLine();
        }
    }

}
