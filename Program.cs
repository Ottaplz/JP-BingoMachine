string input = "";
int MIN = 1;
int MAX = 75;
const int ABSOLUTE_MIN = 1;
const int ABSOLUTE_MAX = 500;
Random rand = new Random();

// Receive input from user for default or custom number range
ProgramWelcome();

if (input == "Y" || input == "YES")
{   
    MIN = InputMin();
    MAX = InputMax(MIN);
}

// Initialise and populate Array from MIN to MAX values desired
int[] BingoBalls = new int[MAX - MIN + 1];
BingoBalls = CreateBingoBalls(MIN, MAX);

// Game loop
bool exit = false;
while (!exit)
{
    int ballsRolled = 0;
    
    PrintCommands();

    while (!exit)
    {   
        Console.Write("\nTYPE COMMAND: ");
        input = Console.ReadLine().ToUpper();
        // Different results for all valid inputs
        switch (input)
        {
            case var rule when input =="END" || input == "Q" || input == "QUIT":
                exit = true;
                break;
            case var rule when input == "ROLL" || input == "R":
                    Shuffle();
                    Roll(BingoBalls, 1, ballsRolled);
                    ballsRolled++;
                    break;
            case var rule when input == "ROLL5" || input == "R5":
                if (ballsRolled > MAX - 5)
                {
                    Console.WriteLine("Sorry you don't have enough balls :(");
                    break;
                }
                else
                {
                    Shuffle();
                    Roll(BingoBalls, 5, ballsRolled);
                    ballsRolled += 5;
                    break;
                }
            case "SENDIT!":
                if (ballsRolled > MAX - 10)
                {
                    Console.WriteLine("Sorry you don't have the balls to send it :(");
                    break;
                }
                else
                {
                    Shuffle();
                    Roll(BingoBalls, 10, ballsRolled);
                    ballsRolled += 10;
                    break;
                }
            case var rule when input == "HELP" || input == "H":
                PrintCommands();
                break;
            default:
                Console.WriteLine("That is not a valid command. Type H or HELP for assistance.");
                break;
        }
        if (ballsRolled == MAX)
        {
            Console.WriteLine("The bingo machine is empty, thanks for playing!");
            exit = true;
        }
    }
    
    return;
}

// Function Definitions

void ProgramWelcome()
{
    bool success = false;
    while (!success)
        {
            Console.WriteLine("Greetings human!");
            Console.WriteLine("Welcome to the Bingo Game!");
            Console.WriteLine("Would you like to set a custom range of numbers? (Y/N)");
            input = Console.ReadLine().ToUpper();
            // Succesful once user input y/n or yes/no
            if (input == "Y" || input == "YES" || input == "N" || input == "NO")
            {
                success = true;
            }
        }
}

int InputMin()
{
    string input = "";
    int value = 0;
    bool success = false;

    // Ensure conditions of correct user input
    while (!success)
    {
        Console.Write("Enter the minimum value: ");
        input = (Console.ReadLine());

        // Ensure valid int 
        success = int.TryParse(input, out value);

        if (success != true)
        {
            Console.WriteLine("Please enter a valid number");
        }
        else if (value > ABSOLUTE_MAX - 1 || value < ABSOLUTE_MIN)
        {
            success = false;
            Console.WriteLine($"Please enter a number between {ABSOLUTE_MIN} and {ABSOLUTE_MAX - 1}");
        }
    }

    return value;
}

int InputMax(int MIN)
{
    string input = "";
    int value = 0;
    bool success = false;

    // Ensure conditions of correct user input
    while (!success)
    {
        Console.Write("Enter the maximum value: ");
        input = (Console.ReadLine());

        // Ensure valid int
        success = int.TryParse(input, out value);
        
        if (success != true)
        {
            Console.WriteLine("Please enter a valid number");
        }
        else if (value <= MIN || value > ABSOLUTE_MAX)
        {
            success = false;
            Console.WriteLine($"Please enter a number between {MIN} and {ABSOLUTE_MAX}");
        }
    }

    return value;
}

int[] CreateBingoBalls(int MIN, int MAX)
{
    int[] BingoBalls = new int[MAX - MIN + 1];

    for (int i = 0; i < MAX; i++)
    {
        BingoBalls[i] = MIN;
        MIN++;
    }

    rand.Shuffle<int> (BingoBalls);

    return BingoBalls;
}

void Shuffle()
{
    Console.WriteLine("           ....SHUFFLING....       ");
    Console.WriteLine("             ___________      ___  ");
    Console.WriteLine("           /             \\   |  _/ ");
    Console.WriteLine("          /               \\  | |   ");
    Console.WriteLine("          |               |__| |   ");
    Console.WriteLine("          |               |____/   ");
    Console.WriteLine("          \\               /        ");
    Console.WriteLine("           \\_____________/         ");
    Console.WriteLine("           \\____|__|___/          ");
    Console.WriteLine("             U   ...   U           ");
    Console.WriteLine("             U   ...   U           ");
    Console.WriteLine("                 ...              ");
    Console.WriteLine("               |     |          ");
    Console.WriteLine("               |     |          ");
    Console.WriteLine("               |_____|          ");
}

void Ball(int num)
{
    Console.WriteLine("                  __     ");
    Console.WriteLine("                /    \\   ");
    Console.WriteLine($"                 | {num} | ");
    Console.WriteLine("                \\ __ /   ");
}

void PrintCommands()
{   
    Console.WriteLine("\nThe commands are as follows:");
    Console.WriteLine("o \"R/ROLL\"- To roll a new ball");
    Console.WriteLine("o \"R5/ROLL5\"- To roll 5 new balls");
    Console.WriteLine("o \"SENDIT!\"- To roll 10 new balls");
    Console.WriteLine("o \"Q/QUIT/END\"- To exit the game");
    Console.WriteLine("o \"H/HELP\"- To get command list");
}

void Roll(int[] BingoBalls, int rollNum, int current)
{
    for (int i = 0; i < rollNum; i++)
    {
        Ball(BingoBalls[current]);
        current++;
    }
}