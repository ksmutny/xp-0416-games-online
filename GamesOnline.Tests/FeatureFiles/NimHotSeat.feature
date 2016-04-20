Feature: NimHotSeat	

Scenario: NewGameNumberOfPiles
       When New game is started
       Then The piles count is more than 1
	   And Player 1 is on the move

Scenario: NewGamePilesSize
       When New game is started
       Then All piles have more coins than 0
	   And Player 1 is on the move

Scenario: TakeCoinsPlayerOne
       Given Piles
       | 1 | 2 | 3 | 7 | 1 |
       And Player 1 is on the move
       When Take 2 coins from pile 3
       Then The piles are
       | 1 | 2 | 1 | 7 | 1 |
	   And Player 2 is on the move

Scenario: TakeCoinsPlayerTwo
       Given Piles
       | 1 | 2 | 3 | 7 | 1 |
       And Player 2 is on the move
       When Take 6 coins from pile 4
       Then The piles are
       | 1 | 2 | 1 | 1 | 1 |
	   And Player 1 is on the move

Scenario: StartNewGamePlayerTwo
       Given Piles
       | 1 | 2 | 3 | 7 |
	   And Player 2 is on the move
       When New game is started
       Then Player 1 is on the move

Scenario: CannotTakeMoreCoinsThanThePileSize
       Given Piles
       | 1 | 2 | 3 | 7 |	   
	   And Player 1 is on the move
       When Take 6 coins from pile 1
	   Then An exception is thrown 
       And Player 1 is on the move

Scenario: CannotTakeCoinsFromNotExistingPile
       Given Piles
       | 1 | 2 | 3 | 7 |	   
	   And Player 1 is on the move
       When Take 6 coins from pile 42
	   Then An exception is thrown 
       And Player 1 is on the move

Scenario: CannotTakeZeroCoins
       Given Piles
       | 1 | 2 | 3 | 7 |	   
	   And Player 1 is on the move
       When Take 0 coins from pile 1
	   Then An exception is thrown 
       And Player 1 is on the move

Scenario: PlayerOneWins
       Given Piles
       | 42 |
	   And Player 1 is on the move
       When Take all coins from the last pile
	   Then Player 1 wins