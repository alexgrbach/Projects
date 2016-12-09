using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TicTacToe
{
    public class functions
    {
        public char[,] boardPlace(char player, int input, char[,] board)
        {

            int iCoord = input / 3;
            int jJcoord = input % 3;

            board[iCoord, jJcoord] = player;
            return board;
        }
        public string drawBoard(char[,] board)
        {
            return ($@"       │       │       
   { board[0, 0]}   │   { board[0, 1]}   │   { board[0, 2]}   
       │       │       
───────┼───────┼───────
       │       │       
   { board[1, 0]}   │   { board[1, 1]}   │   { board[1, 2]}   
       │       │        
───────┼───────┼───────
       │       │       
   { board[2, 0]}   │   { board[2, 1]}   │   { board[2, 2]}   
       │       │       ");

        }
        public bool checkWinner(char[,] board)
        {
            bool status = false;
            for(int i = 0; i < 3; i++)
            {
                if(((board[i,0] == 'X' && board[i, 1] == 'X' && board[i, 2] == 'X') || (board[i, 0] == 'O' && board[i, 1] == 'O' && board[i, 2] == 'O') || (board[0, i] == 'X' && board[1, i] == 'X' && board[2, i] == 'X') || (board[0, i] == 'O' && board[1, i] == 'O' && board[2, i] == 'O')))
                {
                    status = true;
                }
            }
            if (((board[0, 0] == 'X' && board[1, 1] == 'X' && board[2, 2] == 'X') || (board[0, 0] == 'O' && board[1, 1] == 'O' && board[2, 2] == 'O')) || (board[2, 0] == 'X' && board[1, 1] == 'X' && board[0, 2] == 'X') || (board[2, 0] == 'O' && board[1, 1] == 'O' && board[0, 2] == 'O'))
            {
                status = true;
            }//if board == board == board 
            return status;
        }
        public bool badEntry(string entry)
        {
            bool output = false; 
            return output;
        }
        public string errorMessage()
        {
            Random rnd = new Random();
            string[] messages = new string[] { "lol try again!", "Come on you idiot follow directions!", "Eat a dick dumbshit!" , "Hambre was smarter than you will ever be" , "Woah! Stop the presses you did something right for once!\n\nWait... Nevermind..." , "If this was Sparta you would have been thrown off the cliff" , "I bet you're the kind of guy who would fuck a person in the ass and not even have the goddamn common courtesy to give him a reach-around." };
            string output = messages[rnd.Next(0, messages.Length)];
            return output; 
        }
        public bool checkBoard(int input, char[,] board)
        {
            bool status = true;
            
            if (!(input >= 1 && input <= 9))
            {
                status = false;  
            }
            --input;
            int i = input / 3;
            int j = input % 3;
            if (status && (board[i,j] == 'X' || board[i, j] == 'O'))
            {
                 status = false;
            }

            return status;
        }
    }
}
    