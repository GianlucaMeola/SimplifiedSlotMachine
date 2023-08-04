using SimplifiedSlotMachine.Interfaces;
using System;

namespace SimplifiedSlotMachine.Core
{
    public class SlotMachineGameLogic : ISlotMachineGameLogic
    {
        private readonly Random random;

        public SlotMachineGameLogic()
        {
            random = new Random();
        }

        public char[][] GenerateBoard()
        {
            char[][] board = new char[4][];
            for (int i = 0; i < 4; i++)
            {
                board[i] = new char[3];
                for (int j = 0; j < 3; j++)
                {
                    board[i][j] = GetRandomSymbol();
                }
            }
            return board;
        }

        public int CalculateWinAmount(char[][] board, int stakeAmount)
        {
            int winAmount = 0;

            // Check horizontal lines for winning combinations
            for (int i = 0; i < 4; i++)
            {
                double lineCoefficient = GetLineCoefficient(board[i]);
                if (lineCoefficient > 0)
                {
                    winAmount += (int)(lineCoefficient * stakeAmount);
                }
            }

            return winAmount;
        }

        private double GetLineCoefficient(char[] line)
        {
            int wildcardsCount = 0;
            double coefficient = 0;

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '*')
                {
                    wildcardsCount++;
                }
            }

            var noWildLine = this.RemoveWildCard(line);

            if (wildcardsCount == 1)
            {
                if (noWildLine[0] == noWildLine[1])
                    coefficient += 2 * GetSymbolCoefficient(noWildLine[0]);
            }
            else if (wildcardsCount == 2)
            {
                coefficient += GetSymbolCoefficient(noWildLine[0]);
            }
            else if (wildcardsCount == 3)
            {
                coefficient = 0;
            }
            else if (wildcardsCount == 0)
            {
                char matchingSymbol = line[0];
                bool isMatch = true;
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] != matchingSymbol)
                    {
                        isMatch = false;
                        break;
                    }
                }
                if (isMatch) coefficient += Math.Round(3 * GetSymbolCoefficient(matchingSymbol), 1);
            }

            return coefficient;
        }

        private char[] RemoveWildCard(char[] line)
        {
            return line.Where(c => c != '*').ToArray();
        }

        private char GetRandomSymbol()
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

        private static double GetSymbolCoefficient(char symbol)
        {
            switch (symbol)
            {
                case 'A':
                    return 0.4;
                case 'B':
                    return 0.6;
                case 'P':
                    return 0.8;
                case '*':
                    return 0.0;
                default:
                    return 0.0;
            }
        }
    }
}
