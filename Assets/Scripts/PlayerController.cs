using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {

	[SerializeField] List<GameObject> MainPath;
	[SerializeField] NavMeshAgent player;
	int playerPosNum = 1;
	[SerializeField] string playerNumString; // p1,p2,p3,p4

	public void MovePlayerForward() {
		playerPosNum++;
		Vector3 destination = MainPath[playerPosNum - 1].transform.Find(playerNumString).transform.position;
		player.SetDestination(destination);
	}

	public bool IsMoving() {
		if(player.remainingDistance <= 0.1) {
			return false;
		} else {
			return true;
		}
	}
}
