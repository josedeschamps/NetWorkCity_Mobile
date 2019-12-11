using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuAnimation : MonoBehaviour {

	public float animTimer;
	private float timer;
	private bool canAnim = false;

	void Start () {

		timer = animTimer;
		DOTween.Init ();
		transform.DOLocalMoveY (400f, 1.5f).SetEase (Ease.OutBounce).OnComplete (Shake);

		
	}

	void Update(){

		if (canAnim) {

			timer -= Time.deltaTime;

		}

		if (timer < 0) {

			Animate ();
			timer = animTimer;
		}

	}
	
	void Shake(){

		transform.DOPunchScale (new Vector3 (.9f, .9f, 1f), .5f, 10, .5f).SetEase (Ease.OutQuad).OnComplete(Animate);
		canAnim = true;
	}

	void Animate(){

		transform.DOShakeRotation (1f, 90f, 10, 90f, true).SetEase (Ease.OutQuad);

	}
}
