using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialSpace : MonoBehaviour {
	[SerializeField] int spaceType;

	public void UseSpace() {
		if (spaceType == 1) {
			return; // banana coinage
		} else if (spaceType == 2) {
			return; // give card
		} else if (spaceType == 3) {
			return; // shop
		}
	}
}
