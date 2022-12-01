Console.WriteLine("Rock Paper Scissors");

while (true)
{
    Console.WriteLine("Are you ready?");
    Console.WriteLine("Let's begin!");

    string selectedChoice = SelectChoice();
    char yourChoice = char.Parse(selectedChoice);

    Console.WriteLine($"You selected: {yourChoice}");

    var opponentChoice = GetOpponentChoice();
    Console.WriteLine($"Opponent choose: {opponentChoice}");

    DecideWinner(opponentChoice, yourChoice);

    Console.WriteLine("Do you want to play again?");
    Console.WriteLine("Enter Y to play again or any other key to stop...");

    var playAgain = Console.ReadLine();
    if (playAgain?.ToUpper() == "Y")
        continue;
    else
        break;
}

string SelectChoice()
{
    // Question
    Console.WriteLine("Choose R, P, or S: [R]ock, [P]aper, [S]cissors,  ");
    var selectedChoise = Console.ReadLine();

    // ? : Si la variable es distinto de null
    if (selectedChoise?.ToUpper() != "R" &&
        selectedChoise?.ToUpper() != "P" &&
        selectedChoise?.ToUpper() != "S")
    {
        Console.WriteLine("Please, select only one letter: R, P or S");
        // Recursividad
        selectedChoise = SelectChoice();
    }

    return selectedChoise;
}

char GetOpponentChoice()
{
    char[] options = new char[] { 'R', 'P', 'S' };

    Random random = new();

    int randomIndex = random.Next(0, options.Length);

    return options[randomIndex];
}

void DecideWinner(char opponentChoice, char yourChoice)
{
    // Empate
    if (opponentChoice == yourChoice)
    {
        Console.WriteLine("Tie!");
        return;
    }

    switch (yourChoice)
    {
        case 'R':
        case 'r':
            if (opponentChoice == 'P') 
                Console.WriteLine("Paper beats rock, I Win!");
            else if(opponentChoice == 'S')
                Console.WriteLine("Rock beats Scissors, You win!");
            break;

        case 'S':
        case 's':
            if (opponentChoice == 'P')
                Console.WriteLine("Scissors beats paper, You win!");
            else if (opponentChoice == 'R')
                Console.WriteLine("Rock beats Scissors, I Win!");
            break;

        case 'P':
        case 'p':
            if (opponentChoice == 'S')
                Console.WriteLine("Scissors beats paper, You win!");
            else if (opponentChoice == 'R')
                Console.WriteLine("Paper beats Rock, You Win!");
            break;
    }
}