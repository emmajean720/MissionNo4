using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionNo4
{
    internal class TicTacToeTools
    {
        public void PrintBoard(char[,] boardArray)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{boardArray[i,j]}");
                }
                Console.Write("\n");
            }
        }
        public object[] DetermineWinner(char[,] boardArray)
        {
            int x = 0;
            int o = 0;
            bool winner = false;
            char player_won = '-';
            object[] return_array = new object[2];
            char middle_position = '-';

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (boardArray[i,j] == 'X')
                    {
                        x += 1;
                    }

                    else if (boardArray[i,j] == 'O') 
                    {
                        o += 1;
                    }
                }

                if (x == 3)
                {
                    winner = true;
                    player_won = 'X';
                }

                else if (o == 3)
                {
                    winner = true;
                    player_won = 'O';
                }

                else
                {
                    x = 0;
                    o = 0;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (boardArray[j, i] == 'X')
                    {
                        x += 1;
                    }

                    else if (boardArray[j, i] == 'O')
                    {
                        o += 1;
                    }
                }

                if (x == 3)
                {
                    winner = true;
                    player_won = 'X';
                }

                else if (o == 3)
                {
                    winner = true;
                    player_won = 'O';
                }

                else
                {
                    x = 0;
                    o = 0;
                }
            }

            middle_position = boardArray[1, 1];

            if (middle_position != '-')
            {
                if (boardArray[0,0] == middle_position)
                {
                    if (boardArray[2,2] == middle_position)
                    {
                        winner = true;
                        player_won = middle_position;
                    }
                }
                
                if (boardArray[0,2] == middle_position)
                {
                    if (boardArray[2,0] == middle_position)
                    {
                        winner = true;
                        player_won = middle_position;
                    }
                }
            }

            return_array[0] = winner;
            return_array[1] = player_won;

            return return_array;
        }
    }
}
