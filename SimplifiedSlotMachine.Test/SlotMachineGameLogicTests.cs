using SimplifiedSlotMachine.Core;
using Xunit;

namespace SimplifiedSlotMachine.Tests
{
    public class SlotMachineGameLogicTests
    {
        [Fact]
        public void CalculateWinAmount_NoWin_ReturnsZero()
        {
            // Arrange
            var logic = new SlotMachineGameLogic();
            char[][] board = new char[][]
            {
                new char[] { 'B', 'B', 'A' },
                new char[] { 'P', 'A', 'P' },
                new char[] { 'B', 'P', 'P' },
                new char[] { 'A', '*', 'B' }
            };
            int stakeAmount = 100;

            // Act
            int winAmount = logic.CalculateWinAmount(board, stakeAmount);

            // Assert
            Assert.Equal(0, winAmount);
        }

        [Fact]
        public void CalculateWinAmount_OneWin_ReturnsCorrectWinAmount()
        {
            // Arrange
            var logic = new SlotMachineGameLogic();
            char[][] board = new char[][]
            {
                new char[] { 'B', 'B', 'B' },
                new char[] { 'P', 'A', 'P' },
                new char[] { 'B', 'P', 'P' },
                new char[] { 'A', '*', 'B' }
            };
            int stakeAmount = 100;

            // Act
            int winAmount = logic.CalculateWinAmount(board, stakeAmount);

            // Assert
            Assert.Equal(180, winAmount);
        }

        [Fact]
        public void CalculateWinAmount_TwoWins_ReturnsCorrectWinAmount()
        {
            // Arrange
            var logic = new SlotMachineGameLogic();
            char[][] board = new char[][]
            {
                new char[] { 'B', 'B', 'B' },
                new char[] { 'P', 'A', '*' },
                new char[] { '*', 'P', 'P' },
                new char[] { 'A', '*', 'B' }
            };
            int stakeAmount = 100;

            // Act
            int winAmount = logic.CalculateWinAmount(board, stakeAmount);

            // Assert
            Assert.Equal(340, winAmount);
        }

        [Fact]
        public void CalculateWinAmount_ThreeWins_ReturnsCorrectWinAmount()
        {
            // Arrange
            var logic = new SlotMachineGameLogic();
            char[][] board = new char[][]
            {
                new char[] { '*', '*', '*' },
                new char[] { '*', 'A', '*' },
                new char[] { 'P', 'P', 'P' },
                new char[] { 'B', '*', 'B' }
            };
            int stakeAmount = 100;

            // Act
            int winAmount = logic.CalculateWinAmount(board, stakeAmount);

            // Assert
            Assert.Equal(400, winAmount);
        }
    }
}
