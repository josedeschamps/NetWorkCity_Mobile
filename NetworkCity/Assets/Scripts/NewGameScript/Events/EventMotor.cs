using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EventMotor : MonoBehaviour {

	public SideEventMotor SideEvent;

	[Header("CharacterPotrait")]
	public string[] nombre;
	public Text[] charNames;
	public Button[] charButton;
	public Button[] charGoButton;
	public Sprite[] charImages;


	[Header("Loyalty")]
	public Slider[] loyaltyMeters;
	public int[] charMeterValues;

	[Header("Irrel/Clout")]
	public Slider IrrelCloutMeter;
	public Image irrelCloutColor;
	public int irrelCloutValue;


	[Header("Events")]
	public Image eventPanel;
	public Sprite[] eventImg;
	public int eventOrder;
	public Text eventQuestion;
	[TextArea(5,5)]
	public string[] QuestionText;
	public int questionOrder;
	public int choice_1;
	public int choice_2;
	public int choice_3;
	private bool button_01, button_02, button_03 = false;


	[Header("EventsOutComes")]
	public GameObject outCome;
	public Image eventOutComePanel;
	public Sprite[] outComeImages;
	public Text eventResultText;
	[TextArea(5,5)]
	public string[] resultText;
	public int eventOutComeIndex;

	[Header("EventDescriptions")]
	public GameObject eventDescriptionPanel;
	public GameObject[] roastStars;
	public GameObject[] friendlyStars;
	public GameObject[] talentStars;
	public GameObject[] egoStars;

	[Header("GameOver State")]
	public GameObject gameOverPanel;
	private bool isGameOver = false;





	private void Start(){

		DOTween.Init ();

		//adding event sprite and text together.
		eventPanel.sprite = eventImg[eventOrder];
		eventQuestion.text = QuestionText[questionOrder];

		//--add current values for the meters--//
		IrrelCloutMeter.value = irrelCloutValue;

		for (int i = 0; i < loyaltyMeters.Length; i++) {

			loyaltyMeters [i].value = charMeterValues [i];
		}

		for (int i = 0; i < charButton.Length; i++) {

			charButton [i].image.sprite = charImages [i];
			charNames [i].text = nombre [i];
		}




	}


	void Update(){

		CheckSelecter ();
		GameOverState ();
	}


	public void CharacterButtonOne(){

			if (!button_01) {

			for (int i = 0; i < 4; i++) {

				roastStars [i].SetActive (false);
				friendlyStars [i].SetActive (false);
				talentStars [i].SetActive (false);
				egoStars [i].SetActive (false);
				charGoButton [i].gameObject.SetActive (false);
			}
		
			charButton [0].gameObject.transform.DOScale (new Vector3 (1.3f, 1.3f, 1f), .5f).SetEase (Ease.OutElastic);
			Color32 fadeOutColor = new Color32 (131, 95, 95, 255);
			charButton [1].image.DOColor (fadeOutColor, .5f).SetEase (Ease.OutCirc);
			charButton [2].image.DOColor (fadeOutColor, .5f).SetEase (Ease.OutCirc);
			button_01 = true;
			button_02 = false;
			button_03 = false;
			Color32 fadeInColor = new Color32 (255, 255, 255, 255);
			charButton [0].image.DOColor (fadeInColor, .5f).SetEase (Ease.OutCirc);
			charGoButton [0].gameObject.SetActive (true);
		

			for (int i = 0; i < 2; i++) {

				roastStars [i].SetActive (true);
				friendlyStars [i].SetActive (true);
			}

			for (int i = 0; i < 3; i++) {
				talentStars [i].SetActive (true);
				egoStars [i].SetActive (true);
			}

		}
			
			
	}



	public void CharacterButtonTwo(){



		if (!button_02) {

			for (int i = 0; i < 4; i++) {

				roastStars [i].SetActive (false);
				friendlyStars [i].SetActive (false);
				talentStars [i].SetActive (false);
				egoStars [i].SetActive (false);
				charGoButton [i].gameObject.SetActive (false);
			}

			charButton [1].gameObject.transform.DOScale (new Vector3 (1.3f, 1.3f, 1f), .5f).SetEase (Ease.OutElastic);
			Color32 fadeOutColor = new Color32 (131, 95, 95, 255);
			charButton [0].image.DOColor (fadeOutColor, .5f).SetEase (Ease.OutCirc);
			charButton [2].image.DOColor (fadeOutColor, .5f).SetEase (Ease.OutCirc);
			button_01 = false;
			button_02 = true;
			button_03 = false;
			Color32 fadeInColor = new Color32 (255, 255, 255, 255);
			charButton [1].image.DOColor (fadeInColor, .5f).SetEase (Ease.OutCirc);
			charGoButton [1].gameObject.SetActive (true);

			for (int i = 0; i < 3; i++) {

				roastStars [i].SetActive (true);
				egoStars [i].SetActive (true);
			}


			for (int i = 0; i < 1; i++) {
				friendlyStars [i].SetActive (true);
				talentStars [i].SetActive (true);

			}
		} 
	}

	public void CharacterButtonThree(){



		if (!button_03) {

			for (int i = 0; i < 4; i++) {

				roastStars [i].SetActive (false);
				friendlyStars [i].SetActive (false);
				talentStars [i].SetActive (false);
				egoStars [i].SetActive (false);
				charGoButton [i].gameObject.SetActive (false);
			}

			charButton [2].gameObject.transform.DOScale (new Vector3 (1.3f, 1.3f, 1f), .5f).SetEase (Ease.OutElastic);
			Color32 fadeOutColor = new Color32 (131, 95, 95, 255);
			charButton [0].image.DOColor (fadeOutColor, .5f).SetEase (Ease.OutCirc);
			charButton [1].image.DOColor (fadeOutColor, .5f).SetEase (Ease.OutCirc);
			button_01 = false;
			button_02 = false;
			button_03 = true;
			Color32 fadeInColor = new Color32 (255, 255, 255, 255);
			charButton [2].image.DOColor (fadeInColor, .5f).SetEase (Ease.OutCirc);
			charGoButton [2].gameObject.SetActive (true);


			for (int i = 0; i < 1; i++) {

				roastStars [i].SetActive (true);
				egoStars [i].SetActive (true);
			}

			for (int i = 0; i < 3; i++) {
				friendlyStars [i].SetActive (true);
				talentStars [i].SetActive (true);

			}
		} 


	}

	//checking to see which character is selected.
	private void CheckSelecter(){

		if (!button_01) {

			charButton [0].gameObject.transform.DOScale (new Vector3 (1f, 1f, 1f), .5f).SetEase (Ease.OutElastic);
		
		}

		if (!button_02) {

			charButton [1].gameObject.transform.DOScale (new Vector3 (1f, 1f, 1f), .5f).SetEase (Ease.OutElastic);

		}


		if (!button_03) {

			charButton [2].gameObject.transform.DOScale (new Vector3 (1f, 1f, 1f), .5f).SetEase (Ease.OutElastic);

		}

	}

	public void CharSelected(){

		if (button_01){

			charButton [0].gameObject.transform.DOPunchScale (new Vector3 (1.1f, 1.1f, 1f), .5f).SetEase (Ease.OutElastic);
			FirstChoice ();
		}

		if (button_02) {
			charButton [1].gameObject.transform.DOPunchScale (new Vector3 (1.1f, 1.1f, 1f), .5f).SetEase (Ease.OutElastic);
			SecondChoice ();
		}

		if (button_03) {
			charButton [2].gameObject.transform.DOPunchScale (new Vector3 (1.1f, 1.1f, 1f), .5f).SetEase (Ease.OutElastic);
			ThirdChoice ();
		}

	}

	private void FirstChoice(){

		switch (choice_1) 
		{

		case 0:
			DelayADDEffectForMeter (40);
			outCome.transform.DOScaleX (1f, 1.5f).SetEase (Ease.InOutElastic);
			eventOutComePanel.sprite = outComeImages [eventOutComeIndex];
			eventResultText.text = resultText [eventOutComeIndex];
			eventOrder++;
			choice_1++;
			SideEvent.StartSideEvent (0);
			SideEvent.startTimer = true;
			StartCoroutine (ChangeEventOrder ());
			break;

		case 1:
			DelayRemoveEffectForMeter (80);
			outCome.transform.DOScaleX (1f, 1.5f).SetEase (Ease.InOutElastic);
			eventResultText.text = resultText [eventOutComeIndex];
			eventOutComePanel.sprite = outComeImages [eventOutComeIndex];
			choice_1++;
			eventOutComeIndex++;
			break;

		case 2:


			outCome.transform.DOScaleX (1f, 1.5f).SetEase (Ease.InOutElastic);
			eventResultText.text = resultText [eventOutComeIndex];
			choice_1++;
			eventOutComeIndex++;
			break;

		}


	}

	IEnumerator ChangeEventOrder(){
		yield return new WaitForSeconds (1f);
		eventOutComeIndex++;
		questionOrder++;
		eventPanel.sprite = eventImg[eventOrder];
		eventQuestion.text = QuestionText[questionOrder];

	}



	private void SecondChoice(){



	}
		

	private void ThirdChoice(){



	}

	public void EvenOutComeButton(){

		outCome.transform.DOScaleX (0f, 1f).SetEase (Ease.InElastic);
		Color32 fadeInColor = new Color32 (255, 255, 255, 255);
		for (int i = 0; i < charButton.Length; i++) {
			charButton [i].image.DOColor (fadeInColor, .5f);
			charGoButton [i].gameObject.SetActive (false);

		}

		button_01 = button_02 = button_03 = false;

	}


	//-----Adding and Subtract Main Score------/// <summary>
	/// Adds the clout meter.
	/// </summary>
	/// <param name="score">Score.</param>


	private void AddCloutMeter(int score){


		if (score == 100) 
		{
			irrelCloutValue = irrelCloutValue + score;
			return;
		}

		irrelCloutValue= irrelCloutValue + score;
		StartCoroutine (PositiveFadeColor ());


	}


	private void SubtractCloutMeter(int score){


		if (score == 0) 
		{
			irrelCloutValue = irrelCloutValue - score;
			return;
		}

		irrelCloutValue= irrelCloutValue - score;
		StartCoroutine (NegativeFadeColor ());


	}

	private void DelayADDEffectForMeter(int amount){

		StartCoroutine (DelayADDEffect (amount));
	}

	IEnumerator DelayADDEffect(int cloutamount){

		yield return new WaitForSeconds (2f);
		AddCloutMeter (cloutamount);
	}

	private void DelayRemoveEffectForMeter(int amount){

		StartCoroutine (DelayRemoveEffect(amount));
	}

	IEnumerator DelayRemoveEffect(int cloutamount){

		yield return new WaitForSeconds (2f);
		SubtractCloutMeter (cloutamount);
	}

	IEnumerator PositiveFadeColor(){

		IrrelCloutMeter.DOValue (irrelCloutValue, 1f).SetEase (Ease.InOutBounce);
		Color32 fadeInColor = new Color32 (171, 248, 172, 255);
		irrelCloutColor.DOColor(fadeInColor, .5f).SetEase (Ease.OutQuart);
		yield return new WaitForSeconds (1f);
		Color32 fadeOutColor = new Color32 (118, 244, 255, 255);
		irrelCloutColor.DOColor(fadeOutColor, .5f).SetEase (Ease.OutQuart);
	}


	IEnumerator NegativeFadeColor(){

		IrrelCloutMeter.DOValue (irrelCloutValue, 1f).SetEase (Ease.InOutBounce);
		Color32 fadeInColor = new Color32 (255, 103, 124, 255);
		irrelCloutColor.DOColor(fadeInColor, .5f).SetEase (Ease.OutQuart);
		yield return new WaitForSeconds (1f);
		Color32 fadeOutColor = new Color32 (118, 244, 255, 255);
		irrelCloutColor.DOColor(fadeOutColor, .5f).SetEase (Ease.OutQuart);
	}



	//-----Ends Here------//



	private void GameOverState(){

		if (irrelCloutValue <= 0 && !isGameOver) {

			//gameOverPanel.transform.DOMoveY (400, 2f).SetEase (Ease.InOutBounce);
			StartCoroutine(GameOverDelay());
			isGameOver = true;

		}


	}

	IEnumerator GameOverDelay(){

		yield return new WaitForSeconds (2f);
		gameOverPanel.transform.DOMoveY (400, 2f).SetEase (Ease.InOutBounce);
	}














}


