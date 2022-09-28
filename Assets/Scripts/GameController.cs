using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
	[SerializeField] Shop shopScript;
	PlayerController currentPlayer;
	[SerializeField] Image aImage;
	[SerializeField] Image usedCardImageHolder;
	[SerializeField] TextMeshProUGUI rollNumberHolder;
	[SerializeField] Deck cardDeck;
	[SerializeField] GameObject selectionUI;
	[SerializeField] TextMeshProUGUI timerUI;
	int playerTurn = 1;
	int rollNumber = 0;
	string playerPlayCard = "null";
	int playerPlayCardNumber = 5;
	bool cardInUse = true;
	bool cardPlayed = false; bool defenceCardPlayed = false;
	float cardUseTimer = 6f;
	string playerDefenceCard = "null";
	int playerDefenceCardNumber;
	int selectedPlayertoAttack = 5;
	bool playerAttacked = false;
	bool shopOpened = false;
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
				if (!cardPlayed) {
					CheckForPlayCardUse();
				}
				CheckForRoll();
				break;

			case gameState.cardUse:
				aImage.enabled = false;
				rollNumberHolder.enabled = true;
				player1.UpdateMyCards(false);
				player2.UpdateMyCards(false);
				player3.UpdateMyCards(false);
				player4.UpdateMyCards(false);
				if(cardUseTimer <= 0) {
					timerUI.enabled = false;
					if (defenceCardPlayed) {
						UseDefenceCard();
						Debug.Log(playerPlayCard);
						defenceCardPlayed = false;
					}
					cardInUse = UseCard();
					if (!cardInUse) {
						cardPlayed = false;
						playerPlayCard = "null";
						playerPlayCardNumber = 5;
						playerDefenceCard = "null";
						playerDefenceCardNumber = 5;
						currentState = gameState.playerMove;
					}
				} else {
					timerUI.enabled = true;
					timerUI.text = ((int)cardUseTimer).ToString();
					if (!defenceCardPlayed && cardPlayed) {
						CheckForDefenceCardUse();
					}
					cardUseTimer -= Time.deltaTime;
				}
				break;

			case gameState.playerMove:
				if (!currentPlayer.IsMoving()) {
					rollNumberHolder.text = rollNumber.ToString();
					if (rollNumber > 0) {
						currentPlayer.MovePlayerForward();
						rollNumber--;
					} else if (rollNumber <= 0) {
						rollNumberHolder.enabled = false;
						usedCardImageHolder.enabled = false;
						currentState = gameState.destinationReached;
					}
				}
				break;

			case gameState.destinationReached:
				bool actionComplete = false;
				if (currentPlayer.CheckSpace() == 1) {
					// Banana Space
					bananaScript.GiveRandomBananas(currentPlayer);
					actionComplete = true; 
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
					// Shop Space
					if (!shopOpened) {
						shopScript.OpenShopUI(currentPlayer);
						shopOpened = true;
					}
					if (shopScript.GetActionComplete()) {
						shopScript.SetActionComplete();
						actionComplete = true;
						shopOpened = false;
                    } 
					if (shopScript.ButtonClicked()){
						shopScript.RandomCard();
						if (shopScript.GetActionComplete()) {
							shopScript.SetActionComplete();
							actionComplete = true;
							shopOpened = false;
                        }
                    }
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

	private void CheckForPlayCardUse() {
		string pInput = currentPlayer.GetArrowKey();

		if (pInput == "left") {
			playerPlayCardNumber = 0;
		} else if (pInput == "up") {
			playerPlayCardNumber = 1;
		} else if (pInput == "down") {
			playerPlayCardNumber = 2;
		} else if (pInput == "right") {
			playerPlayCardNumber = 3;
		} else {
			return;
		}

		if (currentPlayer.GetCard(true, playerPlayCardNumber) != "null") {
			playerPlayCard = currentPlayer.GetCard(true, playerPlayCardNumber);
			usedCardImageHolder.sprite = cardDeck.FindPlayCardSprite(playerPlayCard);
			currentPlayer.RemoveCard(true, playerPlayCardNumber);
			cardPlayed = true;
			usedCardImageHolder.enabled = true;
		}
	}

	private void SelectPlayerToAttack() {
		string pInput = currentPlayer.GetArrowKey();

		if (pInput == "left") {
			selectedPlayertoAttack = 1;
		} else if (pInput == "up") {
			selectedPlayertoAttack = 2;
		} else if (pInput == "right") {
			selectedPlayertoAttack = 3;
		} else if (pInput == "down") {
			selectedPlayertoAttack = 4;
		} else {
			return;
		}
	}

	private void CheckForDefenceCardUse() {
		for(int i = 0; i < 4; i++) {
			PlayerController pCheck;
			if(i == 0) {
				pCheck = player1;
			} else if(i == 1) {
				pCheck = player2;
			} else if (i == 2) {
				pCheck = player3;
			} else {
				pCheck = player4;
			}

			if(pCheck != currentPlayer) {
				string pInput = pCheck.GetArrowKey();

				if (pInput == "left") {
					playerDefenceCardNumber = 0;
				} else if (pInput == "up") {
					playerDefenceCardNumber = 1;
				} else if (pInput == "down") {
					playerDefenceCardNumber = 2;
				} else if (pInput == "right") {
					playerDefenceCardNumber = 3;
				} else {
					playerDefenceCardNumber = 4;
				}

				if(playerDefenceCardNumber != 4) {
					if (pCheck.GetCard(false, playerDefenceCardNumber) != "null") {
						playerDefenceCard = pCheck.GetCard(false, playerDefenceCardNumber);
						usedCardImageHolder.sprite = cardDeck.FindDefenceCardSprite(playerDefenceCard);
						pCheck.RemoveCard(false, playerDefenceCardNumber);
						defenceCardPlayed = true;
						return;
					}
				}
			}
		}
	}

	private bool UseCard() {
		if (playerPlayCard == "banana") {
			Debug.Log(rollNumber);
			rollNumber = rollNumber * 2;
			rollNumberHolder.text = rollNumber.ToString();
			Debug.Log(rollNumber);
			return false;
		} else if (playerPlayCard == "bomb") {
			selectionUI.SetActive(false);
			if (selectedPlayertoAttack == 5) {
				selectionUI.SetActive(true);
				SelectPlayerToAttack();
			} else if (selectedPlayertoAttack == 1) {
				if (!playerAttacked) {
					SwitchToCamera(1);
					player1.MovePlayerMultiple(-3);
					playerAttacked = true;
				} else {
					if (!player1.IsMoving()) {
						SwitchToCamera(playerTurn);
						selectedPlayertoAttack = 5;
						playerAttacked = false;
						return false;
					}
				}
			} else if (selectedPlayertoAttack == 2) {
				if (!playerAttacked) {
					SwitchToCamera(2);
					player2.MovePlayerMultiple(-3);
					playerAttacked = true;
				} else {
					if (!player2.IsMoving()) {
						SwitchToCamera(playerTurn);
						selectedPlayertoAttack = 5;
						playerAttacked = false;
						return false;
					}
				}
			} else if (selectedPlayertoAttack == 3) {
				if (!playerAttacked) {
					SwitchToCamera(3);
					player3.MovePlayerMultiple(-3);
					playerAttacked = true;
				} else {
					if (!player3.IsMoving()) {
						SwitchToCamera(playerTurn);
						selectedPlayertoAttack = 5;
						playerAttacked = false;
						return false;
					}
				}
			} else if (selectedPlayertoAttack == 4) {
				if (!playerAttacked) {
					SwitchToCamera(4);
					player4.MovePlayerMultiple(-3);
					playerAttacked = true;
				} else {
					if (!player4.IsMoving()) {
						SwitchToCamera(playerTurn);
						selectedPlayertoAttack = 5;
						playerAttacked = false;
						return false;
					}
				}
			}
			return true;
		} else {
			return false;
		}
	}

	private void UseDefenceCard() {
		Debug.Log(playerDefenceCard);
		if (playerDefenceCard == "cancle") {
			playerPlayCard = "null";
			playerPlayCardNumber = 5;
			Debug.Log("played cancle");
			return;
		} else if (playerDefenceCard == "shield") {
			return;
		} else {
			return;
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

	private void CheckForRoll() {
		if(currentPlayer.CheckRollButton()) {
			rollNumber = Random.Range(1, 7);
			rollNumberHolder.text = rollNumber.ToString();
			currentState = gameState.cardUse;
			cardInUse = true;
			cardUseTimer = 6f;
		}
	}

}
