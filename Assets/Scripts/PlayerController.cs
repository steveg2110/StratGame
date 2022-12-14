using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerController : MonoBehaviour {

	[SerializeField] List<GameObject> MainPath;
	[SerializeField] NavMeshAgent player;
	int playerPosNum = 1;
	[SerializeField] GameObject currentSpace;
	[SerializeField] string playerNumString; // p1,p2,p3,p4
	[SerializeField] int pNum;
	[SerializeField] GameController gameController;
	[SerializeField] Image cardOne;
	[SerializeField] Image cardTwo;
	[SerializeField] Image cardThree;
	[SerializeField] Image cardFour;
	[SerializeField] TextMeshProUGUI bananaText;
	[SerializeField] List<string> myPlayCards = new List<string>(4) { "null", "null", "null", "null" };
	[SerializeField] List<string> myDefenceCards = new List<string>(4) { "null", "null", "null", "null" };
	[SerializeField] Deck cardDeck;
	string keyPressed = "null";
	bool hasRolled = false;
	string tempCard = "null";
	int tempCardType = 0; // 0 = null , 1 = play card , 2 = defence card
	[SerializeField] Image displayCard;
	[SerializeField] GameObject info;

	int bananaCount = 0;

	public int GetPlayerPos() {
		return playerPosNum;
	}

	private void Start() {
		UpdateMyCards(true);
		bananaText.text = bananaCount.ToString();
	}

	private void LateUpdate() {
		keyPressed = "null";
		hasRolled = false;
	}

	public string GetArrowKey() {
		return keyPressed;
	}

	public void MovePlayerForward() {
		playerPosNum++;
		if (playerPosNum < 1) {
			playerPosNum = 1;
		} else if (playerPosNum > 120) {
			playerPosNum = 120;
		}
		Vector3 destination = MainPath[playerPosNum - 1].transform.Find(playerNumString).transform.position;
		player.SetDestination(destination);
	}

	public void MovePlayerMultiple(int moveAmount) {

		playerPosNum += moveAmount;
		if (playerPosNum < 1) {
			playerPosNum = 1;
		} else if (playerPosNum > 120) {
			playerPosNum = 120;
		}
		Vector3 destination = MainPath[playerPosNum - 1].transform.Find(playerNumString).transform.position;
		player.SetDestination(destination);
	}

	public int CheckSpace() {
		currentSpace = MainPath[playerPosNum - 1];
		if (currentSpace.GetComponent<SpecialSpace>()) {
			return currentSpace.GetComponent<SpecialSpace>().UseSpace();
		} else {
			return 0;
		}
	}

	public bool IsMoving() {
		if (player.remainingDistance <= 0.25) {
			return false;
		} else {
			return true;
		}
	}

	public void UpdateMyCards(bool playCards) {
		if (playCards) {
			for (int i = 0; i < 4; i++) {
				if (i == 0) {
					cardOne.sprite = cardDeck.FindPlayCardSprite(myPlayCards[i]);
				} else if (i == 1) {
					cardTwo.sprite = cardDeck.FindPlayCardSprite(myPlayCards[i]);
				} else if (i == 2) {
					cardThree.sprite = cardDeck.FindPlayCardSprite(myPlayCards[i]);
				} else {
					cardFour.sprite = cardDeck.FindPlayCardSprite(myPlayCards[i]);
				}
			}
		} else {
			for (int i = 0; i < 4; i++) {
				if (i == 0) {
					cardOne.sprite = cardDeck.FindDefenceCardSprite(myDefenceCards[i]);
				} else if (i == 1) {
					cardTwo.sprite = cardDeck.FindDefenceCardSprite(myDefenceCards[i]);
				} else if (i == 2) {
					cardThree.sprite = cardDeck.FindDefenceCardSprite(myDefenceCards[i]);
				} else {
					cardFour.sprite = cardDeck.FindDefenceCardSprite(myDefenceCards[i]);
				}
			}
		}
	}

	public void GivePlayCard() {
		tempCard = cardDeck.GivePlayCard();
		tempCardType = 1;
	}

	public void GiveDefenceCard() {
		tempCard = cardDeck.GiveDefenceCard();
		tempCardType = 2;
	}

	public string GetCard(bool playCard, int card) {
		if (playCard) {
			return myPlayCards[card];
		} else {
			return myDefenceCards[card];
		}
	}

	public void RemoveCard(bool playCard, int card) {
		if (playCard) {
			myPlayCards[card] = "null";
		} else {
			myDefenceCards[card] = "mull";
		}
	}

	public bool ReplaceCard() {
		displayCard.enabled = true;
		info.SetActive(true);
		if (tempCardType == 1) {
			UpdateMyCards(true);
			displayCard.sprite = cardDeck.FindPlayCardSprite(tempCard);
			if (keyPressed == "left") {
				myPlayCards[0] = tempCard;
				displayCard.enabled = false;
				info.SetActive(false);
				return true;
			} else if (keyPressed == "up") {
				myPlayCards[1] = tempCard;
				displayCard.enabled = false;
				info.SetActive(false);
				return true;
			} else if (keyPressed == "down") {
				myPlayCards[2] = tempCard;
				displayCard.enabled = false;
				info.SetActive(false);
				return true;
			} else if (keyPressed == "right") {
				myPlayCards[3] = tempCard;
				displayCard.enabled = false;
				info.SetActive(false);
				return true;
			} else {
				return false;
			}
		} else {
			UpdateMyCards(false);
			displayCard.sprite = cardDeck.FindDefenceCardSprite(tempCard);
			if (keyPressed == "left") {
				myDefenceCards[0] = tempCard;
				displayCard.enabled = false;
				info.SetActive(false);
				return true;
			} else if (keyPressed == "up") {
				myDefenceCards[1] = tempCard;
				displayCard.enabled = false;
				info.SetActive(false);
				return true;
			} else if (keyPressed == "down") {
				myDefenceCards[2] = tempCard;
				displayCard.enabled = false;
				info.SetActive(false);
				return true;
			} else if (keyPressed == "right") {
				myDefenceCards[3] = tempCard;
				displayCard.enabled = false;
				info.SetActive(false);
				return true;
			} else {
				return false;
			}
		}
	}

	public bool CheckRollButton() {
		return hasRolled;
	}

	public void AddBananas(int bananasToAdd) {
		bananaCount += bananasToAdd;
		bananaText.text = bananaCount.ToString();
	}

	public void RemoveBananas(int bananasToRemove) {
		bananaCount -= bananasToRemove;
		bananaText.text = bananaCount.ToString();
	}

	public int GetBananaCount() {
		return bananaCount;
    }

	//////////////// Input
	public void RollDice(InputAction.CallbackContext context) {
		hasRolled = true;
	}
	public void UseCard1(InputAction.CallbackContext context) {
		keyPressed = "left";
	}
	public void UseCard2(InputAction.CallbackContext context) {
		keyPressed = "up";
	}
	public void UseCard3(InputAction.CallbackContext context) {
		keyPressed = "down";
	}
	public void UseCard4(InputAction.CallbackContext context) {
		keyPressed = "right";
	}

	public void quitGame(InputAction.CallbackContext context) {
		Application.Quit();
	}
}
