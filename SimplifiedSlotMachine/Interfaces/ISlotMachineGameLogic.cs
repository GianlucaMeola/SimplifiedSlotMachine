namespace SimplifiedSlotMachine.Interfaces
{
    public interface ISlotMachineGameLogic
    {
        char[][] GenerateBoard();
        int CalculateWinAmount(char[][] board, int stakeAmount);
    }
}
