using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {
	public List<Sprite> playDeckImages;
	public List<string> playDeckNames;
	public List<Sprite> defenceDeckImages;
	public List<string> defenceDeckNames;

	public Sprite FindPlayCardSprite(string cardName) {
		if (playDeckNames.Contains(cardName)) {
			int cardPos = playDeckNames.IndexOf(cardName);
			return playDeckImages[cardPos];
		} else {
			return playDeckImages[0];
		}
	}

	public Sprite FindDefenceCardSprite(string cardName) {
		if (defenceDeckNames.Contains(cardName)) {
			int cardPos = defenceDeckNames.IndexOf(cardName);
			return defenceDeckImages[cardPos];
		} else {
			return defenceDeckImages[0];
		}
	}
}
