using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SideEventMotor : MonoBehaviour {

	[Header("EventsSideOutComes")]
	public GameObject sideEventPanel;
	public Image sideEventImg;
	public Sprite[] eventImages;
	public Text sideEventText;
	[TextArea(5,5)]
	public string[] eventTexts;
	public int eventIndex;


	[Header("SideQuestTimer")]
	public float timer;
	private float clock;
	public bool startTimer,hasKey = false;

	public float closeTimer;
	private float closeClock;


	void Start () {
		DOTween.Init ();
		clock = timer;
		closeClock = closeTimer;


	}
	

	void Update () {


		if (startTimer) {

			clock -= Time.deltaTime;
		}


		if (clock < 0) {

			SideEventUpdates (eventIndex);
			clock = timer;
			hasKey = true;
			startTimer = false;
		}


		if (hasKey) {

			closeClock -= Time.deltaTime;
		}

		if (closeClock < 0) {
			ReturnToGame ();
			closeClock = closeTimer;
			hasKey = false;
		}
		
	}


	public void ReturnToGame(){

		StartCoroutine (ReturnAnimationUI ());

	}

	IEnumerator ReturnAnimationUI(){
		yield return new WaitForSeconds (.1f);
		sideEventPanel.transform.DOScaleY (0, 1.5f).SetEase (Ease.InOutElastic);


	}

	void SideEventUpdates(int updateIndex){



		switch (updateIndex) {

		case 0:
			sideEventPanel.transform.DOScaleY (1f, 1.5f).SetEase (Ease.InOutElastic);
			sideEventImg.sprite = eventImages [eventIndex];
			sideEventText.text = eventTexts [eventIndex];
			break;

		case 1:
			sideEventPanel.transform.DOScaleY (1f, 1.5f).SetEase (Ease.InOutElastic);
			sideEventImg.sprite = eventImages [eventIndex];
			sideEventText.text = eventTexts [eventIndex];
			break;

		case 2:
			sideEventPanel.transform.DOScaleY (1f, 1.5f).SetEase (Ease.InOutElastic);
			sideEventImg.sprite = eventImages [eventIndex];
			sideEventText.text = eventTexts [eventIndex];
			break;


		}

	}


	public void StartSideEvent(int index){

		index = eventIndex;

	}



}
