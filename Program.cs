using System;
using MissionNo4;

class Program
{
    static char[,] board = new char[3, 3]; // 3x3 game board

    static void Main()
    {
        //Initialize variables we'll use later
        TicTacToeTools tt = new TicTacToeTools();
        bool win = false;
        int row = 0;
        int col = 0;
        int turn = 1;
        object[] winner = [];
        
        //Introduce players to the game
        Console.WriteLine("Welcome to Tic Tac Toe!");
        
        //This function is found below. It creates our board as a 3x3 array of '-'s
        InitializeBoard();
        
        //This method comes from the other class and will print out our game board
        tt.PrintBoard(board);
        
        //We will loop through the game until there is a winner or until 9 turns have passed (after 9 turns
        //there can only be a tie)
        while (win == false)
        {
            //If it's an odd turn, then player 1(X) goes
            if (turn % 2 != 0)
            {
                //Player 1 enters the coordinates for the square they want to target
                Console.WriteLine("Player X, please enter the row number of your target square");
                row = int.Parse(Console.ReadLine()) - 1;
                Console.WriteLine("Player X, please enter the column number of your target square");
                col = int.Parse(Console.ReadLine()) - 1;

                //MakeMove updates the game board with the player's choice
                //If the square targeted is already filled, then the player is notified and takes another turn
                if (MakeMove(row, col, 'X') == false)
                {
                    //We subtract 1 from turn so that when the loop resets, turn will still be odd and let player 1
                    //retry their turn
                    turn -= 1;
                }
                //After the board is updated we print it, check for a winner, and end the game if the player has won
                tt.PrintBoard(board);
                winner = tt.DetermineWinner(board);
                if ((bool)winner[0])
                {
                    Console.WriteLine("Player X won!");
                    win = true;
                }
            }
            
            //If turn is even, then player 2 takes their turn just as player 1 would
            else
            {
                Console.WriteLine("Player O, please enter the row number of your target square");
                row = int.Parse(Console.ReadLine()) - 1;
                Console.WriteLine("Player O, please enter the column number of your target square");
                col = int.Parse(Console.ReadLine()) - 1;

                if (MakeMove(row, col, 'O') == false)
                {
                    turn -= 1;
                }
                tt.PrintBoard(board);
                winner = tt.DetermineWinner(board);
                if ((bool)winner[0])
                {
                    Console.WriteLine("Player O won!");
                    win = true;
                }
            }

            //We add to turn so that it will be the next player's turn
            turn++;
            
            //If turn is greater than 9 that means all the squares must be filled and the result is a tie.
            //In that case we don't want an infinite loop so we notify the players and end the game
            if (turn > 9)
            {
                Console.WriteLine("Tie Game!");
                break;
            }
            
        }

    }

    //This is the function to initialize our game board
    static void InitializeBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                board[i, j] = '-'; // Empty slot
            }
        }
    }

    //This function puts the respective player's mark in the square they've chosen
    //It receives the column//row coordinates for their chosen square, checks if that square is empty, and then
    //puts their mark in that square if available
    static bool MakeMove(int row, int col, char player)
    {
        if (board[row, col] == '-') // Check if spot is available
        {
            board[row, col] = player;
            return true;
        }
        //If the chosen square has already been taken then we let the player choose another square
        else
        {
            Console.WriteLine("Invalid move! Try again.");
            return false;
        }
    }
    
}