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

        Console.WriteLine("What would you like to throw?");
        Console.WriteLine(
            @"1) Rock
2) Paper
3) Scissors"
        );
        int userMoveIdx = Int16.Parse(Console.ReadLine()) - 1;
        int computerMoveIdx = rnd.Next(3);

        // TODO prevent the user from entering a number NOT between 1-3

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
