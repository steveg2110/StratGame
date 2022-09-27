using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : MonoBehaviour
{

    [SerializeField] GameController gameController;

    public void GiveRandomBananas(PlayerController player) {
        int randomBananaNum = Random.Range(1, 3);
        player.AddBananas(randomBananaNum);
    }

}
