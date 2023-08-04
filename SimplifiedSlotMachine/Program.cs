using SimplifiedSlotMachine.Core;
using SimplifiedSlotMachine.Interfaces;
using SimplifiedSlotMachine.IoC;
using System;

namespace SimplifiedSlotMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            var slotMachineUI = new SlotMachineUI(new SlotMachineGameLogic());
            slotMachineUI.StartGame();
        }
    }
}
