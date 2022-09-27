using UnityEngine;

public class GameController : MonoBehaviour {
	[SerializeField] PlayerController player1;
	[SerializeField] PlayerController player2;
	[SerializeField] PlayerController player3;
	[SerializeField] PlayerController player4;
	[SerializeField] GameObject camera1;
	[SerializeField] GameObject camera2;
	[SerializeField] GameObject camera3;
	[SerializeField] GameObject camera4;
	PlayerController currentPlayer;
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

	// Update is called once per frame
	void Update() {
		switch (currentState) {
			case gameState.playerRoll:
				SwitchToCamera(playerTurn);
				SelectPlayerController();
				break;

			case gameState.cardUse:
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
				currentState = gameState.nextPlayer;
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
			rollNumber = Random.Range(1, 6);
			currentState = gameState.cardUse;
		}
	}
}
