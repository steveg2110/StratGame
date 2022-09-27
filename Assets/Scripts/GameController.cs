using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	[SerializeField] PlayerController player1;
	[SerializeField] PlayerController player2;
	[SerializeField] PlayerController player3;
	[SerializeField] PlayerController player4;
	[SerializeField] GameObject camera1;
	[SerializeField] GameObject camera2;
	[SerializeField] GameObject camera3;
	[SerializeField] GameObject camera4;
	[SerializeField] Banana bananaScript;
	PlayerController currentPlayer;
	[SerializeField] Image aImage;
	int playerTurn = 1;
	int rollNumber = 0;
	enum gameState {
		playerRoll,
		cardUse,
		playerMove,
		destinationReached,
		nextPlayer,
	}
	gameState currentState = gameState.playerRoll;
	int randomCardTypeChosen = 0; // 0 = not chosen , 1 = give play card , 2 = give defence card , 3 = selecting card pos

	// Update is called once per frame
	void Update() {
		switch (currentState) {
			case gameState.playerRoll:
				aImage.enabled = true;
				SwitchToCamera(playerTurn);
				SelectPlayerController();
				player1.UpdateMyCards(true);
				player2.UpdateMyCards(true);
				player3.UpdateMyCards(true);
				player4.UpdateMyCards(true);
				break;

			case gameState.cardUse:
				aImage.enabled = false;
				player1.UpdateMyCards(false);
				player2.UpdateMyCards(false);
				player3.UpdateMyCards(false);
				player4.UpdateMyCards(false);
				currentState = gameState.playerMove;
				break;

			case gameState.playerMove:
				if (!currentPlayer.IsMoving()) {
					if (rollNumber > 0) {
						currentPlayer.MovePlayerForward();
						rollNumber--;
					} else if (rollNumber <= 0) {
						currentState = gameState.destinationReached;
					}
				}
				break;

			case gameState.destinationReached:
				bool actionComplete = false;
				if (currentPlayer.CheckSpace() == 1) {
					bananaScript.GiveRandomBananas(currentPlayer);
					actionComplete = true; // banana coinage calls
				} else if (currentPlayer.CheckSpace() == 2) {
					if (randomCardTypeChosen == 0) {
						randomCardTypeChosen = Random.Range(1, 3);
					} else {
						if (randomCardTypeChosen == 1) {
							currentPlayer.GivePlayCard();
							randomCardTypeChosen = 3;
						} else if (randomCardTypeChosen == 2) {
							currentPlayer.GiveDefenceCard();
							randomCardTypeChosen = 3;
						} else {
							if (currentPlayer.ReplaceCard()) {
								actionComplete = true;
								randomCardTypeChosen = 0;
							}
						}
					}
				} else if (currentPlayer.CheckSpace() == 3) {
					actionComplete = true; // replace with shop calls
				} else {
					actionComplete = true;
				}

				if (actionComplete) {
					currentState = gameState.nextPlayer;
				}
				break;

			case gameState.nextPlayer:

				if (playerTurn == 1) {
					playerTurn = 2;
				} else if (playerTurn == 2) {
					playerTurn = 3;
				} else if (playerTurn == 3) {
					playerTurn = 4;
				} else {
					playerTurn = 1;
				}
				currentState = gameState.playerRoll;
				break;
		}
	}

	private void SelectPlayerController() {
		if (playerTurn == 1) {
			currentPlayer = player1;
		} else if (playerTurn == 2) {
			currentPlayer = player2;
		} else if (playerTurn == 3) {
			currentPlayer = player3;
		} else {
			currentPlayer = player4;
		}
	}

	private void SwitchToCamera(int camera) {
		if (camera == 1) {
			camera1.SetActive(true);
			camera2.SetActive(false);
			camera3.SetActive(false);
			camera4.SetActive(false);
		} else if (camera == 2) {
			camera1.SetActive(false);
			camera2.SetActive(true);
			camera3.SetActive(false);
			camera4.SetActive(false);
		} else if (camera == 3) {
			camera1.SetActive(false);
			camera2.SetActive(false);
			camera3.SetActive(true);
			camera4.SetActive(false);
		} else {
			camera1.SetActive(false);
			camera2.SetActive(false);
			camera3.SetActive(false);
			camera4.SetActive(true);
		}
	}

	public void CheckRollDice(int pNum) {
		if(pNum == playerTurn && currentState == gameState.playerRoll) {
			rollNumber = Random.Range(1, 7);
			currentState = gameState.cardUse;
		}
	}
}
