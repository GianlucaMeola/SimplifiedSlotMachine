# Simplified Slot Machine Game

The Simplified Slot Machine Game is a console application that simulates a simplified slot machine. Players can enter their initial deposit amount, and then they can play the slot machine game by staking their money on each spin. The game will display the results of each spin and calculate the win amount based on the winning combinations.

## Features

- Simulated slot machine game with dimensions 4 rows of 3 symbols each.
- Supported symbols with their coefficients and probabilities of appearance:
  - Apple (A) - Coefficient: 0.4, Probability: 45%
  - Banana (B) - Coefficient: 0.6, Probability: 35%
  - Pineapple (P) - Coefficient: 0.8, Probability: 15%
  - Wildcard (*) - Coefficient: 0, Probability: 5%
- Players can stake money on each spin.
- Winning combinations are based on one or more horizontal lines containing 3 matching symbols or combinations with wildcards (*).
- The win amount is calculated as the sum of coefficients of the symbols on the winning line(s), multiplied by the stake amount.

## Getting Started

To play the Simplified Slot Machine Game, follow these steps:

1. Clone or download the project from the GitHub repository: [https://github.com/your-username/SimplifiedSlotMachine](https://github.com/your-username/SimplifiedSlotMachine)

2. Open the project in your preferred C# development environment.

3. Build the solution to ensure all dependencies are resolved.

4. Run the console application.

5. Enter the initial deposit amount when prompted.

6. Start playing the game by entering your stake amount on each spin.

7. The game will display the results of each spin, the win amount, and the current balance.

8. Keep playing until your balance hits 0 or until you choose to exit the game.

## Dependencies

The Simplified Slot Machine Game uses the following libraries:

- `System`: The core C# library for console application development.
- `SimplifiedSlotMachine.Interfaces`: An interface library for the slot machine game logic.

## Unit Tests

The project includes unit tests to ensure the correctness of the game logic and winning combinations. You can run the unit tests to verify the functionality of the game.

## Contributing

Contributions to the Simplified Slot Machine Game are welcome! If you find any issues or have suggestions for improvements, feel free to open an issue or submit a pull request.

Enjoy the game and have fun playing!
