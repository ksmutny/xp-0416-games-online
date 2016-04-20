Feature: NimAI
	
Scenario: ComputerWins
       Given Piles And Computer is on the move
       | 7 |
       When Take all coins from the last pile
          Then Computer wins

Scenario: ComputerIsWinningBeforeMove
       Given State of game before move is LOOSING
          And Computer is on the move
       When Computer makes move
          Then after move state of game is WINNING
And Player 1 is on the move


Scenario: ComputerIsWinningEasyTest
       Given Piles And Computer is on the move
       | 1 | 2 | 
       When Computer makes move
          Then The piles are
              | 1 | 1 |
       And Player 1 is on the move

Scenario: ComputerIsLoosingBeforeMove
       Given State of game before move is WINNING
          And Computer is on the move
       When Computer makes move
       Then after move state of game is LOOSING
          And Player 1 is on the move
          And Count of coins of any pile is less by 1  
