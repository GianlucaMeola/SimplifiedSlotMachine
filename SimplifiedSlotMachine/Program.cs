using System;

namespace SlotMachineGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Slot Machine Game!");

            int depositAmount = GetDepositAmount();
            int totalBalance = depositAmount;

            while (totalBalance > 0)
            {
                int stakeAmount = GetStakeAmount(totalBalance);

                if (stakeAmount > totalBalance)
                {
                    Console.WriteLine("You can't stake more than you have in your balance.");
                    continue; // Loop back to the start and ask for stake amount again
                }

                char[][] board = GenerateBoard();
                DisplayBoard(board);

                int winAmount = CalculateWinAmount(board, stakeAmount);
                totalBalance -= stakeAmount - winAmount;

                Console.WriteLine($"Win amount: {winAmount}");
                Console.WriteLine($"Current balance: {totalBalance}");
            }

            Console.WriteLine("Game over! Your balance hit 0.");
        }

        static int GetDepositAmount()
        {
            Console.Write("Enter your deposit amount: ");
            int depositAmount;
            while (!int.TryParse(Console.ReadLine(), out depositAmount) || depositAmount <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                Console.Write("Enter your deposit amount: ");
            }
            return depositAmount;
        }

        static int GetStakeAmount(int totalBalance)
        {
            Console.Write("Enter your stake amount: ");
            int stakeAmount;
            while (!int.TryParse(Console.ReadLine(), out stakeAmount) || stakeAmount <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                Console.Write("Enter your stake amount: ");
            }
            return stakeAmount;
        }

        static char[][] GenerateBoard()
        {
            var random = new Random();
            char[][] board = new char[4][];
            for (int i = 0; i < 4; i++)
            {
                board[i] = new char[3];
                for (int j = 0; j < 3; j++)
                {
                    board[i][j] = GetRandomSymbol(random);
                }
            }
            return board;
        }

        static char GetRandomSymbol(Random random)
        {
            int num = random.Next(1, 101);
            if (num <= 45)
            {
                return 'A';
            }
            else if (num <= 80)
            {
                return 'B';
            }
            else if (num <= 95)
            {
                return 'P';
            }
            else
            {
                return '*';
            }
        }

        static void DisplayBoard(char[][] board)
        {
            Console.WriteLine("Slot Machine Board:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        static int CalculateWinAmount(char[][] board, int stakeAmount)
        {
            int winAmount = 0;

            // Check horizontal lines for winning combinations
            for (int i = 0; i < 4; i++)
            {
                if (board[i][0] == board[i][1] && board[i][1] == board[i][2])
                {
                    winAmount += (int)(GetSymbolCoefficient(board[i][0]) * stakeAmount);
                }
            }

            return winAmount;
        }

        static double GetSymbolCoefficient(char symbol)
        {
            switch (symbol)
            {
                case 'A':
                    return 0.4;
                case 'B':
                    return 0.6;
                case 'P':
                    return 0.8;
                default:
                    return 0.0;
            }
        }
    }
}
