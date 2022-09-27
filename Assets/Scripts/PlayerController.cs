using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	[SerializeField] List<GameObject> MainPath;
	[SerializeField] NavMeshAgent player;
	int playerPosNum = 1;
	[SerializeField] string playerNumString; // p1,p2,p3,p4
	[SerializeField] int pNum;
	[SerializeField] GameController gameController;
	[SerializeField] Image cardOne;
	[SerializeField] Image cardTwo;
	[SerializeField] Image cardThree;
	[SerializeField] Image cardFour;
	[SerializeField] List<string> myPlayCards = new List<string>(4) { "null", "null", "null", "null" };
	List<string> myDefenceCards = new List<string>(4) { "null", "null", "null", "null" };
	[SerializeField] Deck cardDeck;

	private void Update() {
		UpdateMyCards();
	}

	public void MovePlayerForward() {
		playerPosNum++;
		Vector3 destination = MainPath[playerPosNum - 1].transform.Find(playerNumString).transform.position;
		player.SetDestination(destination);
	}

	public bool IsMoving() {
		if(player.remainingDistance <= 0.25) {
			return false;
		} else {
			return true;
		}
	}

	private void UpdateMyCards() {
		for(int i = 0; i < 4; i++) {
			if(i == 0) {
				cardOne.sprite = cardDeck.FindPlayCardSprite(myPlayCards[i]);
			} else if (i == 1) {
				cardTwo.sprite = cardDeck.FindPlayCardSprite(myPlayCards[i]);
			} else if (i == 2) {
				cardThree.sprite = cardDeck.FindPlayCardSprite(myPlayCards[i]);
			} else {
				cardFour.sprite = cardDeck.FindPlayCardSprite(myPlayCards[i]);
			}
		}
	}

	//////////////// Input
	public void RollDice(InputAction.CallbackContext context) {
		gameController.CheckRollDice(pNum);
	}
	public void UseCard1(InputAction.CallbackContext context) {
		return;
	}
	public void UseCard2(InputAction.CallbackContext context) {
		return;
	}
	public void UseCard3(InputAction.CallbackContext context) {
		return;
	}
	public void UseCard4(InputAction.CallbackContext context) {
		return;
	}


}
