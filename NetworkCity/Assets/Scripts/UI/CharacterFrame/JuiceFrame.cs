using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JuiceFrame : MonoBehaviour {

	public float timer;
	private bool canShake = false;
	public bool hasBeenClicked = false;


	void Start () {

		DOTween.Init ();
		timer = 8f;
	}

	void Update(){


		timer -= Time.deltaTime;

		if (timer < 0 && !canShake && !hasBeenClicked) {

			transform.DOShakeScale (.5f, .2f, 1, .2f, true).SetEase (Ease.OutCirc).OnComplete(Reset);
			canShake = true;

		}


	}


	public void Reset(){

		canShake = false;
		timer = 8f;

	}
}

