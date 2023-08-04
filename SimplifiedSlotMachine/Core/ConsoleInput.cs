using SimplifiedSlotMachine.Interfaces;

namespace SimplifiedSlotMachine.Core
{
    internal class ConsoleInput : IDepositStakeInput
    {
        public int GetDepositAmount()
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

        public int GetStakeAmount(int totalBalance)
        {
            Console.Write("Enter your stake amount: ");
            int stakeAmount;
            while (!int.TryParse(Console.ReadLine(), out stakeAmount) || stakeAmount <= 0 || stakeAmount > totalBalance)
            {
                if (stakeAmount > totalBalance)
                {
                    Console.WriteLine("You can't stake more than you have in your balance.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                }
                Console.Write("Enter your stake amount: ");
            }
            return stakeAmount;
        }
    }
}
