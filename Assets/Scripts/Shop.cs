using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject shopUI;
	[SerializeField] Button playCard;
	[SerializeField] Button DefenseCard;
    PlayerController player;
	bool actionComplete = false;
	bool buttonClicked = false;
	int cardType = 0;

    public void OpenShopUI(PlayerController currentPlayer) {
        shopUI.SetActive(true);
        player = currentPlayer;
	}

	public void PlayCardButton() {
		if (player.GetBananaCount() >= 5) {
			Debug.Log("Play");
			cardType = 1;
			buttonClicked = true;
			shopUI.SetActive(false);
			player.RemoveBananas(5);
		}
	}

	public void DefenseCardButton() {
		if (player.GetBananaCount() >= 3) {
			Debug.Log("Defense");
			cardType = 2;
			buttonClicked = true;
			shopUI.SetActive(false);
			player.RemoveBananas(3);
		}
	}

	public void ExitShopButton() {
		shopUI.SetActive(false);
		actionComplete = true;
    }

	public void RandomCard() {
		if (cardType == 1) {
			player.GivePlayCard();
			cardType = 3;
		} else if (cardType == 2) {
			player.GiveDefenceCard();
			cardType = 3;
		} else {
			if (player.ReplaceCard()) {
				cardType = 0;
				actionComplete = true;
			}

		}
	}


	public bool GetActionComplete() {
		return actionComplete;
    }

	public void SetActionComplete() {
		actionComplete = false;
		buttonClicked = false;
    }
	
	public bool ButtonClicked() {
		return buttonClicked;
    }

}


