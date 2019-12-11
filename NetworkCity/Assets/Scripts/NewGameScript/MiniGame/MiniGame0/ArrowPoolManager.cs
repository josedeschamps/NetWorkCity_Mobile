using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ArrowPoolManager : MonoBehaviour {


	public static ArrowPoolManager current;
	public int poolAmount;
	public GameObject arrow;
	public List<GameObject> totalArrows;
	public bool willGrow = true;



	void Awake(){

		current = this;
	}

	void Start(){

		totalArrows = new List<GameObject> ();
		DOTween.Init ();

		for (int i = 0; i < poolAmount; i++) {
			GameObject obj = (GameObject)Instantiate (arrow);
			obj.SetActive (false);
			totalArrows.Add (obj);
	
		}


		StartArrow ();
	
	}



	public GameObject GetPooledObject(){

		for (int i = 0; i < totalArrows.Count; i++) {

	
			if (!totalArrows [i].activeInHierarchy) {

				return totalArrows [i];
			}
	}


		if(willGrow){

			GameObject obj = (GameObject)Instantiate (arrow);
			totalArrows.Add (obj);
			return obj;

		}

		return null;


}
	private void StartArrow(){

		GameObject newArrow = GetPooledObject ();

		if (newArrow == null)
			return;
		newArrow.transform.position = transform.position;
		newArrow.transform.rotation = transform.rotation;
		newArrow.SetActive (true);
	}


	public void RespawnArrow(){

		GameObject newArrow = GetPooledObject ();

		if (newArrow == null)
			return;
			newArrow.transform.position = transform.position;
			newArrow.transform.rotation = transform.rotation;
			newArrow.SetActive (true);
		    newArrow.transform.DOPunchScale (new Vector3 (0.4f, 1.1f, 1f), .5f, 10, 1).SetEase (Ease.InBounce);

	}


}
