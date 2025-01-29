using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionNo4
{
    internal class TicTacToeTools
    {
        public void PrintBoard(char[,] boardArray) // Returns nothing, just prints the board
        {
            
            for (int i = 0; i < 3; i++) // Loops through every row of the board
            {
                for (int j = 0; j < 3; j++) // Loops through ever column of the board
                {
                    Console.Write($"{boardArray[i,j]}");
                }
                Console.Write("\n"); // Write a new line for each row
            }
        }

        /* Method returns object array with boolean saying if someone won in 0 position
           and char of the player that won in the 1 position, default '-' if no winner */
        public object[] DetermineWinner(char[,] boardArray) 
        {
            int x = 0; // Counter for determining if x won
            int o = 0; // Counter for determing if o won
            bool winner = false;
            char player_won = '-';
            object[] return_array = new object[2];
            char middle_position = '-'; // Will store char in middle position for determining diagonal winners

            // Check for winner across a row
            for (int i = 0; i < 3; i++) // Loops through rows
            {
                for (int j = 0; j < 3; j++)
                {
                    if (boardArray[i,j] == 'X') // Loops through columns
                    {
                        x += 1; // Add one for every x in row
                    }

                    else if (boardArray[i,j] == 'O') 
                    {
                        o += 1; // Add one for every o in row
                    }
                }

                if (x == 3) // if 3 x's in a row, set x as winner
                {
                    winner = true;
                    player_won = 'X';
                }

                else if (o == 3) // or if 3 o's in a row, set o as winner
                {
                    winner = true;
                    player_won = 'O';
                }

                else // if no winner in row, reset counter
                {
                    x = 0; 
                    o = 0;
                }
            }

            // Check for winner across a column
            for (int i = 0; i < 3; i++) // Loops through columns
            {
                for (int j = 0; j < 3; j++) // Loops through rows
                {
                    if (boardArray[j, i] == 'X')
                    {
                        x += 1; // Add one for every x in column
                    }

                    else if (boardArray[j, i] == 'O')
                    {
                        o += 1; // Add one for every o in column
                    }
                }

                if (x == 3) // if 3 x's in a column, set x as winner
                {
                    winner = true;
                    player_won = 'X';
                }

                else if (o == 3) // if 3 o's in a column, set o as winner
                {
                    winner = true;
                    player_won = 'O';
                }

                else // if no winner in column, reset counters
                {
                    x = 0;
                    o = 0;
                }
            }

            middle_position = boardArray[1, 1]; // determine middle position

            if (middle_position != '-') // if the middle position is occupied, check for diagonals
            {

                // if top left and bottom right corners match middle, set the winner
                if (boardArray[0,0] == middle_position)
                {
                    if (boardArray[2,2] == middle_position)
                    {
                        winner = true;
                        player_won = middle_position;
                    }
                }
                
                // if top right and bottom left corners match middle, set the winner
                if (boardArray[0,2] == middle_position)
                {
                    if (boardArray[2,0] == middle_position)
                    {
                        winner = true;
                        player_won = middle_position;
                    }
                }
            }

            // output results
            return_array[0] = winner;
            return_array[1] = player_won;

            return return_array;
        }
    }
}
