using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;  

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] playerNames = new string[2];
            Console.WriteLine("Tic Tac Toe!\n");
            Console.Write("Which of youze be X: ");
            playerNames[0] = Console.ReadLine();
            Console.Write("Who is the fool that got stuck with O: ");
            playerNames[1] = Console.ReadLine();
            bool playAgain = false; 
            do
            {
                functions func = new functions();
                char[,] board = new char[,] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
                bool win = func.checkWinner(board);
                bool isNotTaken = true;
                bool isInteger;
                bool gameOver = false;
                String choice = "";
                int choiceInt = -1;
                for (int i = 0; i < 10 && !win; i++)
                {
                    Console.Clear();
                    Console.WriteLine(func.drawBoard(board));
                    switch (i)
                    {
                        case 0:
                            Console.Write($"You up First { playerNames[0] }\n\nPick a spot 1-9: ");
                            choice = Console.ReadLine();
                              break;

                        case 1:
                            Console.Write($"Great Choice { playerNames[0] }!\n\nIt your turn { playerNames[1] }!\n\nPick 1-9: ");
                            choice = Console.ReadLine();
                            break;
                        case 2:
                            Console.Write($"Woah there {playerNames[1]}! That was a ballzy move!\n\nYou know the drill {playerNames[0]}: ");
                            choice = Console.ReadLine();
                            break;
                        case 3:
                            Console.Write($"Aww come on {playerNames[0]}! That was an awful play!\n\nDo better than that {playerNames[1]}! ");
                            choice = Console.ReadLine();
                            break;
                        case 4:
                            Console.Write($"Aww man! This game is starting to heat up!\n\nPlace your X like your life depends on it {playerNames[0]}! ");
                            choice = Console.ReadLine();
                            break;
                        case 5:
                            Console.Write($"Great play {playerNames[0]}! You live to see another day!\n\n{playerNames[1]} beat this fool already! ");
                            choice = Console.ReadLine();
                            break;
                        case 6:
                            Console.Write($"Is this game really still going on?\n\nI guess so {playerNames[0]} just pick already! ");
                            choice = Console.ReadLine();
                            break;
                        case 7:
                            Console.Write($"Lowest steak game ever!\n\n{playerNames[1]} pick before i die of boredom! ");
                            choice = Console.ReadLine();
                            break;
                        case 8:
                            Console.Write($"Oh man only 1 spot left! I wonder where {playerNames[0]} is going to pick? ");
                            choice = Console.ReadLine();
                            break;
                        case 9:
                            Console.WriteLine($"Welp you done goofed and tied the game!");
                            gameOver = true;
                            break;
                    }
                    //check for bad input here!
                    isInteger = int.TryParse(choice, out choiceInt);
                    if (isInteger)
                    {
                        isNotTaken = func.checkBoard(choiceInt, board);
                    }
                   while ((!isNotTaken || !isInteger) && !gameOver)
                    {
                        Console.Clear();
                        Console.WriteLine(func.drawBoard(board));
                        string errorMessage = func.errorMessage();
                        Console.WriteLine(errorMessage);
                        Console.Write($"\nTry again {playerNames[i % 2]}: ");
                        choice = Console.ReadLine();
                        isInteger = int.TryParse(choice, out choiceInt);
                        if (isInteger)
                        {
                            isNotTaken = func.checkBoard(choiceInt, board);
                        }
                    }

                    choiceInt--;
                    if (i % 2 == 0 && i < 9)
                    {
                        func.boardPlace('X', choiceInt, board);
                        win = func.checkWinner(board);
                    }
                    else if (i % 2 == 1 && i < 9)
                    {
                        func.boardPlace('O', choiceInt, board);
                        win = func.checkWinner(board);
                        
                    }
                    if (win)
                    {
                        Console.Clear();
                        Console.WriteLine(func.drawBoard(board));
                        Console.WriteLine($"Wow {playerNames[i % 2]} actually won!");
                        i = 11;
                    }
                }

                //play again prompt goes here

                Console.Write("\n\nAre you quitting on me? Well, are you? Then quit, you slimy fucking walrus-looking piece of shit! (Q or Quit): ");
                string response = Console.ReadLine();
                switch (response.ToUpper())
                {
                    case "Q":
                    case "QUIT":
                        playAgain = false;
                        break;
                    default:
                        playAgain = true;
                        break;
                }
            } while (playAgain);
        }//end main

    }
}
