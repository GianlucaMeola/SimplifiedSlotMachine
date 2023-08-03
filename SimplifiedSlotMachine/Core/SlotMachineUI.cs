using SimplifiedSlotMachine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifiedSlotMachine.Core
{
    public class SlotMachineUI
    {
        private readonly ISlotMachineGameLogic slotMachineGameLogic;

        public SlotMachineUI(ISlotMachineGameLogic slotMachineGameLogic)
        {
            this.slotMachineGameLogic = slotMachineGameLogic;
        }

        public void StartGame()
        {
            Console.WriteLine("Welcome to the Slot Machine Game!");

            IDepositStakeInput inputHandler = new ConsoleInput();
            int depositAmount = inputHandler.GetDepositAmount();
            int totalBalance = depositAmount;

            while (totalBalance > 0)
            {
                int stakeAmount = inputHandler.GetStakeAmount(totalBalance);

                if (stakeAmount > totalBalance)
                {
                    Console.WriteLine("You can't stake more than you have in your balance.");
                    continue; // Loop back to the start and ask for stake amount again
                }

                char[][] board = slotMachineGameLogic.GenerateBoard();
                DisplayBoard(board);

                int winAmount = slotMachineGameLogic.CalculateWinAmount(board, stakeAmount);
                totalBalance -= stakeAmount - winAmount;

                Console.WriteLine($"Win amount: {winAmount}");
                Console.WriteLine($"Current balance: {totalBalance}");
            }

            Console.WriteLine("Game over! Your balance hit 0.");
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
    }
}
