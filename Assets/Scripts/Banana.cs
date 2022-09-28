using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{

    [SerializeField] GameController gameController;

    public void GiveRandomBananas(PlayerController player) {
        int randomBananaNum = Random.Range(2, 4);
        player.AddBananas(randomBananaNum);
    }

}
