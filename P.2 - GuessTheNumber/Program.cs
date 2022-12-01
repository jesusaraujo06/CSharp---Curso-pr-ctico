using System.Numerics;

Console.WriteLine("Guess The Number");

StartGame();

void StartGame()
{
    Random random = new Random();
    var randomNumber = random.Next(1, 10);

    Console.WriteLine("Hello! Welcome to the game...");
    Console.WriteLine("What is your name?");

    var player = Console.ReadLine();

    WantToPlay(player, randomNumber);
}

void WantToPlay(string? player, int randomNumber)
{
    Console.WriteLine($"Hi {player}, are you ready to play? (Enter Yes/No)");

    var wantToPlay = Console.ReadLine();

    switch (wantToPlay?.ToLower().Trim())
    {
        case "yes":
            Play(randomNumber);
            break;

        case "no":
            DontPlay();
            break;

        default:
            Console.WriteLine("That is not a valid option.");

            // Recursividad
            WantToPlay(player, randomNumber);
            break;
    }
}

void Play(int randomNumber)
{
    try
    {
        Console.WriteLine("Pick a number between 1 and 10");
        var pickedNumber = Console.ReadLine();

        if(pickedNumber is null) throw new Exception("You need to pick a value!");

        if (int.Parse(pickedNumber) < 1 || int.Parse(pickedNumber) > 10) throw new Exception("Please pick a number beetwen 1 and 10");

        if(int.Parse(pickedNumber) == randomNumber)
        {
            Console.WriteLine("Nice! You guessed the number!");
        }
        else if (int.Parse(pickedNumber) < randomNumber)
        {
            Console.WriteLine("Try again! You guessed the number is higher...");
            Play(randomNumber);
        }
        else if (int.Parse(pickedNumber) > randomNumber)
        {
            Console.WriteLine("Try again! You guessed the number is lower...");
            Play(randomNumber);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine($"Thee has been an error: {e.Message}");
        Play(randomNumber);
    }
}

void DontPlay()
{
    Console.WriteLine("Okey, bye!");
}