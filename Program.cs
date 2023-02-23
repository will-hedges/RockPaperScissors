using System;
using System.Collections.Generic;

Main();

void Main()
{
    PlayGame();
}

void DisplayScoreboard(int userScore, int computerScore)
{
    Console.WriteLine($"-----------------------------");
    Console.WriteLine($"| Player: {userScore}  |  Computer: {computerScore} |");
    Console.WriteLine($"-----------------------------");
}

int GetUserMove()
{
    while (true)
    {
        Console.WriteLine("What would you like to throw?");
        Console.WriteLine(
            @"1) Rock
2) Paper
3) Scissors"
        );
        string userInput = Console.ReadLine().Trim();

        // exit on no input
        if (userInput == "")
        {
            Environment.Exit(0);
        }

        // validate the user input
        int userInt = Int16.Parse(userInput);
        if (userInt >= 1 && userInt <= 3)
        {
            return userInt - 1;
        }
        else
        {
            Console.WriteLine("\nPlease choose a number between 1 and 3.\n");
            continue;
        }
    }
}

void PlayGame()
{
    int userScore = 0;
    int computerScore = 0;

    while (true)
    {
        DisplayScoreboard(userScore, computerScore);
        List<string> moves = new List<string>() { "rock", "paper", "scissors" };
        List<string> throws = new List<string>()
        {
            @"
    _______
---'   ____)
      (_____)
      (_____)
      (____)
---.__(___)
    ",
            @"
    _______
---'   ____)____
          ______)
          _______)
        _______)
---.__________)
    ",
            @"
    _______
---'   ____)____
          ______)
         ________)
        (____)
---.__(___)
    "
        };
        Random rnd = new Random();

        int userMoveIdx = GetUserMove();
        int computerMoveIdx = rnd.Next(3);

        string userMove = moves[userMoveIdx];
        string computerMove = moves[computerMoveIdx];

        string userThrow = throws[userMoveIdx];
        string computerThrow = throws[computerMoveIdx];

        Console.WriteLine(userThrow);
        Console.WriteLine("VS");
        Console.WriteLine(computerThrow);

        // ignore ties
        switch (userMove)
        {
            case "rock":
                if (computerMove == "paper")
                {
                    computerScore++;
                }
                else if (computerMove == "scissors")
                {
                    userScore++;
                }
                break;

            case "paper":
                if (computerMove == "scissors")
                {
                    computerScore++;
                }
                else if (computerMove == "rock")
                {
                    userScore++;
                }
                break;

            case "scissors":
                if (computerMove == "rock")
                {
                    computerScore++;
                }
                else if (computerMove == "paper")
                {
                    userScore++;
                }
                break;
        }
    }
}
