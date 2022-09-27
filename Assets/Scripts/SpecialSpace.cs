using UnityEngine;

public class SpecialSpace : MonoBehaviour {
	[SerializeField] int spaceType;

	public int UseSpace() {
		return spaceType; // 1 = Banana coins , 2 = Random card , 3 = shop , 4 = snake , 5 = ladder
	}
}
