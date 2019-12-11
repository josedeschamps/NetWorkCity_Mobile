using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMotor : MonoBehaviour {
	
	void Update(){

		if (Input.GetKeyDown (KeyCode.Space)) {

			ArrowPoolManager.current.RespawnArrow ();

		}
	}




	private void DelaySpawn(){

		StartCoroutine (DelayTimer ());
	}

	IEnumerator DelayTimer(){

		yield return new WaitForSeconds (.5f);
		ArrowPoolManager.current.RespawnArrow ();
	}



	void OnCollisionEnter2D (Collision2D other){

		if (other.gameObject.CompareTag ("Arrow")) {

			DelaySpawn ();

	}
}




}
