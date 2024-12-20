string input = "";
int MIN = 1;
int MAX = 75;
const int ABSOLUTE_MIN = 1;
const int ABSOLUTE_MAX = 500;

// Receive input from user for default or custom number range
ProgramWelcome();

if (input == "Y" || input == "YES")
{   
    MIN = InputMin();
    MAX = InputMax(MIN);
}

Console.WriteLine($"Range: {MIN} to {MAX}");

// Initialise and populate Array from MIN to MAX values desired
CreateBingoBalls(MIN, MAX);


// Function Definitions

void ProgramWelcome()
{
    bool success = false;
    while (!success)
        {
            Console.WriteLine("Would you like to set a custom range of numbers? (Y/N)");
            input = Console.ReadLine().ToString().ToUpper();
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
        Console.WriteLine("Enter the minimum value: ");
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
        Console.WriteLine("Enter the maximum value: ");
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

    return BingoBalls;
}