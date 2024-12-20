string input = "";
int MIN = 1;
int MAX = 75;
bool success = false;

// Receive input from user for default or custom number range
ProgramWelcome(success);

if (input == "Y" || input == "YES")
{   
    MIN = InputMin(success);
    MAX = InputMax(success, MIN);
}

Console.WriteLine($"Range: {MIN} to {MAX}");

// Initialise and populate Array from MIN to MAX values desired
CreateBingoBalls(MIN, MAX);


// Function Definitions

void ProgramWelcome(bool success)
{
    while (!success)
        {
            Console.WriteLine("Would you like to set a custom range of numbers? (Y/N)");
            input = Console.ReadLine().ToString().ToUpper();
            if (input == "Y" || input == "YES" || input == "N" || input == "NO")
            {
                success = true;
            }
        }
}

int InputMin(bool success)
{
    string input = "";
    int value = 0;

    // Ensure conditions of correct user input
    while (success != true && value < 10000)
    {
        Console.WriteLine("Enter the minimum value: ");
        input = (Console.ReadLine());
        success = int.TryParse(input, out value);
        if (success != true)
        {
            Console.WriteLine("Please enter a valid number");
        }
        else if (value > 10000)
        {
            Console.WriteLine("Please enter a number under 10000");
        }
    }
    return value;
}

int InputMax(bool success, int MIN)
{
    string input = "";
    int value = 0;

    // Ensure conditions of correct user input
    while (success != true && value < 10000)
    {
        Console.WriteLine("Enter the maximum value: ");
        input = (Console.ReadLine());
        success = int.TryParse(input, out value);
        if (success != true)
        {
            Console.WriteLine("Please enter a valid number");
        }
        else if (value <= MIN && value > 1000000)
        {
            Console.WriteLine("Please enter a number higher than the minimum and less than 1,000,000");
        }
    }
    return value;
}



int[] CreateBingoBalls(int MIN, int MAX)
{
    int[] BingoBalls = new int[MAX - MIN + 1]
    for (int i = 0; i <= MAX)
}