using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ArrowUI : MonoBehaviour {

	public Text[] allGameText;
	private bool hasTap;


	void Start () {
		
		DOTween.Init ();
		hasTap = false;
	}
	

	void Update () {

		if (Input.GetMouseButtonDown (0) && !hasTap) {

			for (int i = 0; i < allGameText.Length; i++) {

				allGameText [i].DOFade (0, 1f).SetEase (Ease.InOutQuart);
				hasTap = true;

			}

			GameDelay ();

		}
	}



	private void GameDelay(){

		StartCoroutine (DelayTime ());
	}

	IEnumerator DelayTime(){

		yield return new WaitForSeconds (1f);
		ArrowMotor.hasKey = true;

	}
}
