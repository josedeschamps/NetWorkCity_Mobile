using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ArrowMotor : MonoBehaviour {

	public float throwSpeed;
	private Rigidbody2D RB2D;
	private ScoreManager sm;
	public static bool hasKey;



	void Start () {

		hasKey = false;
		RB2D = GetComponent<Rigidbody2D> ();
		DOTween.Init ();
		sm = GameObject.FindGameObjectWithTag ("ScoreManager").GetComponent<ScoreManager> ();

		
	}
	

	void Update () {


		if (Input.GetMouseButtonDown (0) && hasKey) {

			ArrowMovement ();
		}


	}



	private void ArrowMovement(){

		//RB2D.velocity = new Vector2 (0f, throwSpeed * Time.deltaTime);
	   //transform.DOMoveY (throwSpeed * Time.deltaTime, 0.25f).SetEase (Ease.InElastic);
		RB2D.DOMoveY(4, .8f).SetEase (Ease.InOutExpo);


	}


	void OnCollisionEnter2D (Collision2D other){

		if (other.gameObject.CompareTag ("Goal")) {

			other.gameObject.transform.DOPunchScale(new Vector3(1.1f,1.1f,1f),0.5f,10,1).SetEase(Ease.OutBounce);
			sm.AddScore (1);
			gameObject.SetActive (false);

		}

	}
}
