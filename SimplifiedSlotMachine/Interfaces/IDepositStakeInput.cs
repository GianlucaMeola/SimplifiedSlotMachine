namespace SimplifiedSlotMachine.Interfaces
{
    public interface IDepositStakeInput
    {
        int GetDepositAmount();
        int GetStakeAmount(int totalBalance);
    }
}
