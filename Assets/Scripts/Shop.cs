using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject shopUI;
    PlayerController player;
    public void OpenShopUI(PlayerController currentPlayer) {
        shopUI.SetActive(true);
        player = currentPlayer;
    }
}
