using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class EventMotor1 : MonoBehaviour {


	public SideEventMotor SideEvent;
	public SFXControl sfxControl;
	public JuicyButton juicyButton;


	[Header("FullPanelController")]
	public GameObject fullPanelController;

	[Header("CharacterPotrait")]
	public string[] nombre;
	public Text[] charNames;
	public Button[] charButton;
	public Button[] charGoButton;
	public Sprite[] charImages;
	public GameObject[] chatBubble;
	public Text[] chatBText;
	[TextArea(5,5)]
	public string[]chatDialogue;
	private int dialogueIndex;

	[Header("ButtonClickSpeed")]
	public float timeBetweenClick = 0.5f;
	private float timeStamp;


	[Header("Loyalty")]
	public Slider loyaltyMeters;
	public int charMeterValues;

	[Header("Irrel/Clout")]
	public Slider IrrelCloutMeter;
	public Image irrelCloutColor;
	public int irrelCloutValue;
	public Text AddEffect;
	public Text RemoveEffect;


	[Header("Events")]
	public Animator eventpanelAnim;
	public Image eventPanel;
	public Image backgroundPanel;
	public Sprite[] eventImg;
	public Sprite[] backgroundImg;
	public int eventOrder;
	public Text eventQuestion;
	public GameObject mainPanel;
	[TextArea(5,5)]
	public string[] QuestionText;
	public int questionOrder;
	public int choice_1;
	public int choice_2;
	public int choice_3;
	private bool button_01, button_02, button_03 = false;


	[Header("EventsAnimation")]
	public float timer;
	private float counter;
	private bool canAnim = true;



	[Header("EventsOutComes")]
	public GameObject outCome;
	public Image eventOutComePanel;
	public Image eventOutComeBG;
	public Sprite[] outComeImages;
	public Sprite[] outComeBGImages;
	public Text eventResultText;
	[TextArea(5,5)]
	public string[] resultText;
	public int eventOutComeIndex;
	public GameObject eventOutComeButton;
	private bool hasKey = true;

	[Header("EventDescriptions")]
	public GameObject eventDescriptionPanel;
	public GameObject[] roastStars;
	public GameObject[] friendlyStars;
	public GameObject[] talentStars;
	public GameObject[] egoStars;

	[Header("GameOver State")]
	public GameObject gameOverPanel;
	private bool isGameOver = false;

	[Header("Game Win State")]
	private bool IsWinOver = false;
	private bool hasWon = false;
	public Animator fader;





	private void Start(){

		DOTween.Init ();
		counter = timer;
		//adding event sprite and text together.
		eventPanel.sprite = eventImg[eventOrder];
		backgroundPanel.sprite = backgroundImg [eventOrder];
		eventQuestion.text = QuestionText[questionOrder];


		//--add current values for the meters--//
		IrrelCloutMeter.value = irrelCloutValue;
		loyaltyMeters.value = charMeterValues;


		for (int i = 0; i < charButton.Length; i++) {

			charButton [i].image.sprite = charImages [i];
			charNames [i].text = nombre [i];
		}

	}


	void Update(){

		CheckSelecter ();
		GameWinState ();
		GameOverState ();
		AnimateEventPanel ();


			
	}


	public void CharacterButton(int buttonIndex){



		switch (buttonIndex) {

		case 0: 
			ResetCharacterStars ();
			SelectedCharacterButton (0, 1, 2, true, false, false);
			ShowCharactersStars (3,1,2,3);
			sfxControl.sfxSounds [5].Play ();
		break;

		case 1: 
			ResetCharacterStars ();
			SelectedCharacterButton (1, 0, 2, false, true, false);
			ShowCharactersStars (2,3,2,2);
			sfxControl.sfxSounds [6].Play ();
		break;

		case 2: 
			ResetCharacterStars ();
			SelectedCharacterButton (2, 0, 1, false, false, true);
			ShowCharactersStars (1,2,3,1);
			sfxControl.sfxSounds [7].Play ();
		break;


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

	//Confirming the character choice
	public void CharSelected(){

		if (Time.time >= timeStamp && button_01){

			FirstChoice ();
			timeStamp = Time.time + timeBetweenClick;
		
		}

		if (Time.time >= timeStamp && button_02 ) {

			SecondChoice ();
			timeStamp = Time.time + timeBetweenClick;
		}

		if (Time.time >= timeStamp && button_03) {

			ThirdChoice ();
			timeStamp = Time.time + timeBetweenClick;
		}

	}

	//Choice1
	private void FirstChoice(){

		switch (choice_1) 
		{

		case 0:
			DelayADDEffectForMeter (10);
			StartCoroutine (EventFlipTransition (0));
			sfxControl.sfxSounds [13].Play ();
			eventOutComePanel.sprite = outComeImages [0];
			eventOutComeBG.sprite = outComeBGImages [0];
			eventResultText.text = resultText [0];
			choice_1++;
			choice_2++;
			choice_3++;

			break;

		case 1:
			DelayRemoveEffectForMeter (20);
			StartCoroutine (EventFlipTransition (0));
			eventResultText.text = resultText [1];
			eventOutComeBG.sprite = outComeBGImages[1];
			eventOutComePanel.sprite = outComeImages [1];
			choice_1++;
			choice_2++;
			choice_3++;
			break;

		case 2:

			DelayADDEffectForMeter (15);
			StartCoroutine (EventFlipTransition (0));
			eventResultText.text = resultText [2];
			eventOutComeBG.sprite = outComeBGImages[2];
			eventOutComePanel.sprite = outComeImages [2];
			choice_1++;
			choice_2++;
			choice_3++;
			
			break;

		case 3:
			DelayADDEffectForMeter (15);
			StartCoroutine (EventFlipTransition (0));
			eventResultText.text = resultText [3];
			eventOutComeBG.sprite = outComeBGImages[3];
			eventOutComePanel.sprite = outComeImages [3];
			choice_1++;
			choice_2++;
			choice_3++;
			break;

		case 4:

			DelayRemoveEffectForMeter (100);
			StartCoroutine (EventFlipTransition (0));
			eventResultText.text = resultText [4];
			eventOutComeBG.sprite = outComeBGImages[4];
			eventOutComePanel.sprite = outComeImages [4];
			choice_1++;
			choice_2++;
			choice_3++;
			break;

	

		}


	}

	//Choice2
	private void SecondChoice(){

		int BGselect;
		BGselect = Random.Range (0, outComeBGImages.Length);
		switch (choice_2) 
		{

		case 0:
			DelayADDEffectForMeter (10);
			StartCoroutine (EventFlipTransition (1));
			sfxControl.sfxSounds [13].Play ();
			eventOutComePanel.sprite = outComeImages [5];
			eventOutComeBG.sprite = outComeBGImages[BGselect];
			eventResultText.text = resultText [5];
			choice_1++;
			choice_2++;
			choice_3++;
			break;

		case 1:
			DelayADDEffectForMeter (10);
			StartCoroutine (EventFlipTransition (1));
			eventResultText.text = resultText [6];
			eventOutComeBG.sprite = outComeBGImages[BGselect];
			eventOutComePanel.sprite = outComeImages [6];
			choice_1++;
			choice_2++;
			choice_3++;
			break;

		case 2:
			
				DelayRemoveEffectForMeter (10);
				StartCoroutine (EventFlipTransition (1));
				eventResultText.text = resultText [7];
			    eventOutComeBG.sprite = outComeBGImages[BGselect];
				eventOutComePanel.sprite = outComeImages [7];
			choice_1++;
			choice_2++;
			choice_3++;
			break;


		case 3:

				DelayADDEffectForMeter (15);
				StartCoroutine (EventFlipTransition (1));
				eventResultText.text = resultText [8];
			    eventOutComeBG.sprite = outComeBGImages[BGselect];
				eventOutComePanel.sprite = outComeImages [8];
			choice_1++;
			choice_2++;
			choice_3++;
			break;

		case 4:

				DelayADDEffectForMeter (100);
				StartCoroutine (EventFlipTransition (1));
				eventResultText.text = resultText [9];
				eventOutComeBG.sprite = outComeBGImages[BGselect];
				eventOutComePanel.sprite = outComeImages [9];
			choice_1++;
			choice_2++;
			choice_3++;
			break;
		}



	}

	//Choice3
	private void ThirdChoice(){

		int BGselect;
		BGselect = Random.Range (0, outComeBGImages.Length);

		switch (choice_3) 
		{

		case 0:
			DelayRemoveEffectForMeter (10);
			StartCoroutine (EventFlipTransition (2));
			sfxControl.sfxSounds [18].Play ();
			eventOutComePanel.sprite = outComeImages [10];
			eventOutComeBG.sprite = outComeBGImages[BGselect];
			eventResultText.text = resultText [10];
			choice_1++;
			choice_2++;
			choice_3++;
			break;


		case 1:
			DelayADDEffectForMeter (15);
			StartCoroutine (EventFlipTransition (2));
			eventOutComePanel.sprite = outComeImages [11];
			eventOutComeBG.sprite = outComeBGImages[BGselect];
			eventResultText.text = resultText [11];
			choice_1++;
			choice_2++;
			choice_3++;
			break;

		case 2:
			DelayRemoveEffectForMeter (20);
			StartCoroutine (EventFlipTransition (2));
			eventOutComePanel.sprite = outComeImages [12];
			eventOutComeBG.sprite = outComeBGImages[BGselect];
			eventResultText.text = resultText [12];
			choice_1++;
			choice_2++;
			choice_3++;
			break;


		case 3:
			DelayADDEffectForMeter (20);
			StartCoroutine (EventFlipTransition (2));
			eventOutComePanel.sprite = outComeImages [13];
			eventOutComeBG.sprite = outComeBGImages[BGselect];
			eventResultText.text = resultText [13];
			choice_1++;
			choice_2++;
			choice_3++;
			break;

		case 4:
			DelayADDEffectForMeter (100);
			StartCoroutine (EventFlipTransition (2));
			eventOutComePanel.sprite = outComeImages [14];
			eventOutComeBG.sprite = outComeBGImages[BGselect];
			eventResultText.text = resultText [14];
			choice_1++;
			choice_2++;
			choice_3++;
			break;

		}






	}

	IEnumerator EventFlipTransition(int buttonIndex){
		juicyButton.hasBeenClicked = false;
		sfxControl.sfxSounds [8].Play ();
		charButton [buttonIndex].gameObject.transform.DOPunchScale (new Vector3 (1.1f, 1.1f, 1f), .5f).SetEase (Ease.OutElastic);
		yield return new WaitForSeconds (.2f);
		mainPanel.transform.DORotate (new Vector3 (0f, 90f, 0f), .25f).SetEase(Ease.OutQuad);
		sfxControl.sfxSounds [4].Play ();
		yield return new WaitForSeconds (.2f);
		outCome.transform.DORotate (new Vector3 (0f, 180f, 0f), .25f).SetEase(Ease.OutQuad);



	}

	public void EvenOutComeButton(){

		if (hasKey && !hasWon) {
			juicyButton.hasBeenClicked = true;
			StartCoroutine (ChangeEventOrder ());
	
		}

		if (hasWon) {
			juicyButton.hasBeenClicked = true;
			StartCoroutine(GameWinDelay());
			hasKey = false;
		}

	}
	IEnumerator ChangeEventOrder(){


		sfxControl.sfxSounds [0].Play ();
		eventOutComeButton.transform.DOPunchScale (new Vector3 (1.1f, 1.1f, 1f), .25f, 2, 1f).SetEase (Ease.OutQuad);
		yield return new WaitForSeconds (.2f);
		sfxControl.sfxSounds [3].Play ();
		fullPanelController.transform.DOLocalMoveX (800f, .25f).SetEase (Ease.InBounce);
		yield return new WaitForSeconds (.5f);
		fullPanelController.transform.localPosition = new Vector2(-900,0);
		eventPanel.DOFade (0, 0f);
		eventPanel.transform.DOLocalMoveY (-600f, .25f);
		yield return new WaitForSeconds (.5f);
		questionOrder++;
		eventOrder++;
		eventPanel.sprite = eventImg[eventOrder];
		backgroundPanel.sprite = backgroundImg [eventOrder];
		eventQuestion.text = QuestionText[questionOrder];
		sfxControl.sfxSounds [8].Play ();
		fullPanelController.transform.DOLocalMoveX (10f, .25f).SetEase (Ease.OutQuad);
		outCome.transform.eulerAngles = new Vector2 (0f, 90f);
		mainPanel.transform.eulerAngles = new Vector2 (0f, 0f);
		Color32 fadeInColor = new Color32 (255, 255, 255, 255);
		for (int i = 0; i < charButton.Length; i++) {
			charButton [i].image.DOColor (fadeInColor, .5f);
			charGoButton [i].gameObject.SetActive (false);
			chatBubble [i].SetActive (false);
		}

		button_01 = button_02 = button_03 = false;

		if (eventOrder == 1) {
			
			PlayCharacterVoice (14);

		}

		if (eventOrder == 2) {

			PlayCharacterVoice (15);
		}

		if (eventOrder == 3) {

			PlayCharacterVoice (16);
		}

		if (eventOrder == 4) {

			PlayCharacterVoice (17);
		}


	}


	//-----Adding and Subtract Main Score------/// <summary>



	private void AddCloutMeter(int score){


		if (score == 110) 
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

		irrelCloutValue = irrelCloutValue - score;
		StartCoroutine (NegativeFadeColor ());


	}

	private void DelayADDEffectForMeter(int amount){

		StartCoroutine (DelayADDEffect (amount));
	}

	IEnumerator DelayADDEffect(int cloutamount){

		yield return new WaitForSeconds (1f);
		AddCloutMeter (cloutamount);
		AddEffect.text = "+ " + cloutamount + " Clout";
		AddEffect.gameObject.SetActive (true);
		AddEffect.gameObject.transform.DOLocalMoveY (100f, 1.5f).SetEase (Ease.InOutQuad);
		yield return new WaitForSeconds (1f);
		AddEffect.gameObject.SetActive (false);
		AddEffect.gameObject.transform.DOLocalMoveY (-200f, 1.5f);


	}

	private void DelayRemoveEffectForMeter(int amount){

		StartCoroutine (DelayRemoveEffect(amount));
	}

	IEnumerator DelayRemoveEffect(int cloutamount){

		yield return new WaitForSeconds (1f);
		SubtractCloutMeter (cloutamount);
		RemoveEffect.text = "- "  + cloutamount + " Clout";
		RemoveEffect.gameObject.SetActive (true);
		RemoveEffect.gameObject.transform.DOLocalMoveY (100f, 1.5f).SetEase (Ease.InOutQuad);
		yield return new WaitForSeconds (1f);
		RemoveEffect.gameObject.SetActive (false);
		RemoveEffect.gameObject.transform.DOLocalMoveY (-200f, 1.5f);
	
	}

	IEnumerator PositiveFadeColor(){

		IrrelCloutMeter.DOValue (irrelCloutValue, .25f).SetEase (Ease.OutQuad);
		Color32 fadeInColor = new Color32 (171, 248, 172, 255);
		irrelCloutColor.DOColor(fadeInColor, .5f).SetEase (Ease.OutQuart);
		sfxControl.sfxSounds [11].Play ();
		yield return new WaitForSeconds (1f);
		Color32 fadeOutColor = new Color32 (118, 244, 255, 255);
		irrelCloutColor.DOColor(fadeOutColor, .5f).SetEase (Ease.OutQuart);
	}


	IEnumerator NegativeFadeColor(){

		IrrelCloutMeter.DOValue (irrelCloutValue, 1f).SetEase (Ease.InOutBounce);
		Color32 fadeInColor = new Color32 (255, 103, 124, 255);
		irrelCloutColor.DOColor(fadeInColor, .5f).SetEase (Ease.OutQuart);
		sfxControl.sfxSounds [10].Play ();
		eventOutComePanel.transform.DOShakeRotation (1.5f, 90f, 10, 35f, true).SetEase (Ease.OutQuad);
		yield return new WaitForSeconds (1f);
		Color32 fadeOutColor = new Color32 (118, 244, 255, 255);
		irrelCloutColor.DOColor(fadeOutColor, .5f).SetEase (Ease.OutQuart);
	}



	//-----Ends Here------//

	private void GameWinState(){

		if (irrelCloutValue >= 100 && !IsWinOver) {

			IsWinOver = true;
			hasKey = false;
			hasWon = true;

		}
	}

	IEnumerator GameWinDelay(){
		sfxControl.sfxSounds [0].Play ();
		eventOutComeButton.transform.DOPunchScale (new Vector3 (1.1f, 1.1f, 1f), .25f, 2, 1f).SetEase (Ease.OutQuad);
		yield return new WaitForSeconds (1f);
		fader.SetBool ("SetFader", true);
		yield return new WaitForSeconds (1f);
		SceneManager.LoadScene ("WinState");


	}

	private void GameOverState(){

		if (irrelCloutValue <= 0 && !isGameOver) {

			StartCoroutine(GameOverDelay());
			isGameOver = true;
			hasKey = false;

		}


	}

	IEnumerator GameOverDelay(){

		yield return new WaitForSeconds (2f);
		gameOverPanel.transform.DOLocalMoveY (100, 1.5f).SetEase (Ease.InOutBounce);
		yield return new WaitForSeconds (1f);
		sfxControl.sfxSounds [12].Play ();
	}


	private void ShowCharactersStars(int rStars, int tStars, int fStars, int eStars){

		for (int i = 0; i < rStars; i++) {

			roastStars [i].SetActive (true);
		}

		for (int i = 0; i < tStars; i++) {

			talentStars [i].SetActive (true);

		}

		for (int i = 0; i < fStars; i++) {
			friendlyStars [i].SetActive (true);
		}

		for (int i = 0; i < eStars; i++) {

			egoStars [i].SetActive (true);
		}


	}
	private void ResetCharacterStars(){

		for (int i = 0; i < 3; i++) {

			roastStars [i].SetActive (false);
			friendlyStars [i].SetActive (false);
			talentStars [i].SetActive (false);
			egoStars [i].SetActive (false);
			charGoButton [i].gameObject.SetActive (false);
			chatBubble [i].SetActive (false);
		}


	}
	private void SelectedCharacterButton(int first, int second, int third, bool slot01, bool slot02, bool slot03){

		charButton [first].gameObject.transform.DOScale (new Vector3 (1.3f, 1.3f, 1f), .5f).SetEase (Ease.OutElastic);
		Color32 fadeOutColor = new Color32 (255, 255, 255, 255);
		charButton [second].image.DOColor (fadeOutColor, .5f).SetEase (Ease.OutCirc);
		charButton [third].image.DOColor (fadeOutColor, .5f).SetEase (Ease.OutCirc);
		button_01 = slot01;
		button_02 = slot02;
		button_03 = slot03;
		Color32 fadeInColor = new Color32 (255, 255, 255, 255);
		charButton [first].image.DOColor (fadeInColor, .5f).SetEase (Ease.OutCirc);
		charGoButton [first].gameObject.SetActive (true);
		chatBubble [first].SetActive (true);
		dialogueIndex = Random.Range (0, chatDialogue.Length);
		chatBText[first].text = chatDialogue[dialogueIndex];

	}

	private void FlashPortrait(int charIndex){

		StartCoroutine (CharacterPortraitFlash (charIndex));
	}
		
	private void AnimateEventPanel(){



		if (canAnim) {
			counter -= Time.deltaTime;
		}

		if (counter < 0) {

			eventPanel.transform.DOShakeRotation (1.5f, 10f, 10, 35f, true).SetEase (Ease.OutQuad);
			counter = timer;
		}

	}
	private void AnimateEventOutCome(){

		if (!canAnim) {
			counter -= Time.deltaTime;
		}

		if (counter < 0) {

			eventPanel.DOFade (0, 2f);
			eventPanel.transform.DOShakeRotation (1.5f, 10f, 10, 35f, true).SetEase (Ease.OutQuad);
			counter = timer;
		} 

		

		}
			

	private void PlayCharacterVoice(int voiceIndex){

		StartCoroutine(VoiceAnimation(voiceIndex));
	}
	

	IEnumerator VoiceAnimation(int voiceIndex){


		yield return new WaitForSeconds (1f);
		eventPanel.transform.DOLocalMoveY (8f, 1f).SetEase (Ease.InQuad);
		yield return new WaitForSeconds (.2f);
		eventpanelAnim.SetBool ("SetFade", true);
		sfxControl.sfxSounds [voiceIndex].Play ();


	}

	IEnumerator CharacterPortraitFlash(int charIndex){


		Color32 whateverColor = new Color32(171,248,172,255);
		for(int i = 0; i < 2; i++)
		{
			charButton[charIndex].image.color = Color.white;
			yield return new WaitForSeconds (.1F);
			charButton[charIndex].image.color  = whateverColor;
			yield return new WaitForSeconds (.1F);
		}
		charButton[charIndex].image.color  = Color.white;

	}
}
