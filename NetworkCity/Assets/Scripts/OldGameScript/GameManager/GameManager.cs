using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class GameManager : MonoBehaviour {

	public Sprite[] characterPortrait;
	public List<Sprite> TotalPortrait = new List<Sprite> ();
	public int characterIndex;

	[TextArea]
	public string[] characterNameText;
	[TextArea]
	public string[] charactersText;
	private int characterSlot;

	public Text nameText;
	public Text descriptionText;
	//public Text chatBox;
	public Image characterBox;
	public Image profileBox;

	private float likeScore;
	private float followScore;
	private float cashScore;
	private float viewScore;

	public Slider likeMeter;
	public Slider followMeter;
	public Slider cashMeter;
	public Slider viewMeter;


	public Animator chatBoxAnim;
	//private bool hasntSelected;

	public GameObject[] GUIButton;
	public JuicyButton JB;
	public JuicyButton JB2;
	public JuiceFrame JF;
	public bool hasSelected = true;


	public Image Gameover;
	private bool hasGameOver = false;




	//I need to add more meter, icons and win state. 


	void Start(){


		DOTween.Init ();
		LoadCharacter ();
		
		likeScore = 100f;
		followScore = 100f;
		cashScore = 100f;
		viewScore = 100f;
		likeMeter.value = likeScore;
		followMeter.value = followScore;
		cashMeter.value = cashScore;
		viewMeter.value = viewScore;


		//characterBox.sprite = characterPortrait [0];
		//nameText.text = characterNameText [0];
		//descriptionText.text = charactersText [0];

		characterIndex = Random.Range (0, TotalPortrait.Count);
		characterSlot = characterIndex;
		characterBox.sprite = TotalPortrait [characterSlot];
		nameText.text = characterNameText [characterSlot];
		descriptionText.text = charactersText [characterSlot];

		profileBox.gameObject.transform.DOLocalMoveX (0f, 1f).SetEase(Ease.InOutBack);

		hasSelected = true;

		//----Dont delete this----??
		//characterSlot = Random.Range (0, characterPortrait.Length);
		//profileText.text = "Welcome to network city";
		//profileText.DOText("Welcome to network city", 3f, false, ScrambleMode.All).SetEase(Ease.InOutQuad);
		//-----Ends here-----///


	}


	void Update(){




		if (likeScore < 0f && !hasGameOver ||followScore < 0f && !hasGameOver ||
			cashScore < 0f && !hasGameOver || viewScore < 0f && !hasGameOver){

			GameoverState ();
		}


		if (Input.GetKeyDown (KeyCode.Space)) {

			GameoverState ();
		}

		if (Input.GetKeyDown (KeyCode.A)) {
			SelectCharacter ();

		}
			

	}


	void LoadCharacter(){


		for (int i = 0; i < characterPortrait.Length; i++) {

			TotalPortrait.Add (characterPortrait [i]);
		}

	}

	void SelectCharacter(){

		if (TotalPortrait.Count <= 0) {

			LoadCharacter ();
		}
		characterIndex = Random.Range (0, TotalPortrait.Count);
		characterSlot = characterIndex;
		characterBox.sprite = TotalPortrait [characterSlot];
		TotalPortrait.RemoveAt (characterIndex);

	}
		


	public void Monetization(){


		if (hasSelected) {
			GUIButton [0].transform.DOPunchScale (new Vector3 (.8f, .8f, 1.0f), 0.2f).SetEase (Ease.InOutQuad);
			characterBox.color = new Color (0f, 255f, 0f);
			ChangeCharacter ();
			CheckCharacterLeftButton ();
			JB.hasBeenClicked = true;
			JB.timer = 5f;
			JF.hasBeenClicked = true;
			JF.timer = 8f;
		
		}

		hasSelected = false;


	}


	public void Dismonetization(){
		if (hasSelected) {
			GUIButton [1].transform.DOPunchScale (new Vector3 (.8f, .8f, 1.0f), 0.2f).SetEase (Ease.InOutQuad);
			characterBox.color = new Color (255f, 0f, 0f, 65f);
			//chatBoxAnim.SetTrigger ("SlideRight");
			ChangeCharacter ();
			CheckCharacterRightButton ();
			JB2.hasBeenClicked = true;
			JB2.timer = 5f;
			JF.hasBeenClicked = true;
			JF.timer = 8f;

		}

		hasSelected = false;
	}



	void CheckCharacterLeftButton(){
		switch (characterSlot)
		{
		case 0:
			
			nameText.text = characterNameText [0];
			descriptionText.text = charactersText [0];
			LikePositiveScore (10f);
			FollowPositiveScore (10f);
			CashPositiveScore (5f);
			ViewNegativeScore (20f);
			break;

		case 1:

			nameText.text = characterNameText [1];
			descriptionText.text = charactersText [1];
			LikeNegativeScore (10f);
			FollowPositiveScore (10f);
			CashNegativeScore (10f);
			ViewPositiveScore (30f);
			break;
		
		case 2:
			
			nameText.text = characterNameText [2];
			descriptionText.text = charactersText [2];
			LikePositiveScore (10f);
			FollowNegativeScore (5f);
			CashPositiveScore (5f);
			ViewPositiveScore (5f);
			break;

		case 3:
			
			nameText.text = characterNameText [3];
			descriptionText.text = charactersText [3];
			LikeNegativeScore (40f);
			FollowPositiveScore (10f);
			CashNegativeScore (10f);
			ViewPositiveScore (20f);
			break;

		case 4:
			
			nameText.text = characterNameText [4];
			descriptionText.text = charactersText [4];
			LikePositiveScore (20f);
			CashPositiveScore (15f);
			break;
		case 5:
			
			nameText.text = characterNameText [5];
			descriptionText.text = charactersText [5];
			ViewPositiveScore (30f);
			FollowPositiveScore (10f);
			break;

		case 6:
			
			nameText.text = characterNameText [6];
			descriptionText.text = charactersText [6];
			LikePositiveScore (15f);
			FollowPositiveScore (15f);
			break;

		case 7:
			
			nameText.text = characterNameText [7];
			descriptionText.text = charactersText [7];
			LikeNegativeScore (20f);
			FollowPositiveScore (10f);
			CashNegativeScore (20f);
			ViewPositiveScore (20f);
			break;

		case 8:

			nameText.text = characterNameText [8];
			descriptionText.text = charactersText [8];
			CashNegativeScore (20f);
			LikePositiveScore (20f);
			break;
		
		case 9:

			nameText.text = characterNameText [9];
			descriptionText.text = charactersText [9];
			ViewNegativeScore (20f);
			FollowNegativeScore (20f);
			CashPositiveScore (20f);
			break;
		
		case 10:
			
			nameText.text = characterNameText [10];
			descriptionText.text = charactersText [10];
			ViewPositiveScore (20f);
			FollowPositiveScore (10f);
			break;
		
		case 11:
			
			nameText.text = characterNameText [11];
			descriptionText.text = charactersText [11];
			LikePositiveScore (10f);
			FollowPositiveScore (10f);
			ViewPositiveScore (10f);
			break;

		case 12:

			nameText.text = characterNameText [12];
			descriptionText.text = charactersText [12];
			CashPositiveScore (20f);
			ViewNegativeScore (20f);
			break;
	
		case 13:

			nameText.text = characterNameText [13];
			descriptionText.text = charactersText [13];
			FollowPositiveScore (20f);
			ViewPositiveScore (10f);
			break;
		
		case 14:

			nameText.text = characterNameText [14];
			descriptionText.text = charactersText [14];
			LikePositiveScore (10f);
			FollowPositiveScore (10f);
			CashNegativeScore (20f);
			ViewPositiveScore (10f);
			break;

		case 15:

			nameText.text = characterNameText [15];
			descriptionText.text = charactersText [15];
			ViewNegativeScore (15f);
			FollowNegativeScore (15f);
			break;

		case 16:
			
			nameText.text = characterNameText [16];
			descriptionText.text = charactersText [16];
			LikePositiveScore (20f);
			CashPositiveScore (20f);
			ViewPositiveScore (20f);
			break;

		case 17:
			
			nameText.text = characterNameText [17];
			descriptionText.text = charactersText [17];
			ViewPositiveScore (10f);
			CashNegativeScore (20f);
			break;
		
		case 18:
			
			nameText.text = characterNameText [18];
			descriptionText.text = charactersText [18];
			LikePositiveScore (10f);
			FollowNegativeScore (30f);
			ViewPositiveScore (10f);
			CashPositiveScore (10f);
			break;

		case 19:
			
			nameText.text = characterNameText [19];
			descriptionText.text = charactersText [19];
			CashNegativeScore (10f);
			ViewNegativeScore (40f);
			FollowNegativeScore (20f);
			break;

		case 20:

			nameText.text = characterNameText [20];
			descriptionText.text = charactersText [20];
			ViewNegativeScore (20f);
			LikePositiveScore (10f);
			CashNegativeScore (20f);
			break;

		case 21:

			nameText.text = characterNameText [21];
			descriptionText.text = charactersText [21];
			FollowNegativeScore (40f);
			ViewNegativeScore (10f);
			CashPositiveScore (10f);
			break;
	
		case 22:

			nameText.text = characterNameText [22];
			descriptionText.text = charactersText [22];
			LikeNegativeScore (30f);
			FollowNegativeScore (40f);
			break;

		case 23:

			nameText.text = characterNameText [23];
			descriptionText.text = charactersText [23];
			LikePositiveScore (20f);
			ViewPositiveScore (20f);
			FollowPositiveScore (20f);
			break;

		case 24:
			
			nameText.text = characterNameText [24];
			descriptionText.text = charactersText [24];
			CashNegativeScore (20f);
			ViewPositiveScore (20f);
			break;

		case 25:

			nameText.text = characterNameText [25];
			descriptionText.text = charactersText [25];
			LikeNegativeScore (20f);
			ViewNegativeScore (20f);
			CashPositiveScore (20f);
			break;
		
		case 26:

			nameText.text = characterNameText [26];
			descriptionText.text = charactersText [26];
			FollowPositiveScore (10f);
			CashNegativeScore (5f);
			break;

		case 27:

			nameText.text = characterNameText [27];
			descriptionText.text = charactersText [27];
			CashNegativeScore (30f);
			FollowPositiveScore (10f);
			ViewNegativeScore (30f);
			break;

		case 28:

			nameText.text = characterNameText [28];
			descriptionText.text = charactersText [28];
			ViewNegativeScore (20f);
			CashPositiveScore (20f);
			break;

		case 29:
			
			nameText.text = characterNameText [29];
			descriptionText.text = charactersText [29];
			CashNegativeScore (20f);
			ViewPositiveScore (15f);
			break;

		case 30:
			
			nameText.text = characterNameText [30];
			descriptionText.text = charactersText [30];
			FollowPositiveScore (10f);
			ViewNegativeScore (40f);
			break;

	

		}
	}



	void CheckCharacterRightButton(){

		switch (characterSlot)
		{
		case 0:

			nameText.text = characterNameText [0];
			descriptionText.text = charactersText [0];
			CashPositiveScore (30f);
			ViewNegativeScore (40f);
			break;

		case 1:

			nameText.text = characterNameText [1];
			descriptionText.text = charactersText [1];
			LikePositiveScore (30f);
			FollowNegativeScore (30f);
			break;

		case 2:

			nameText.text = characterNameText [2];
			descriptionText.text = charactersText [2];
			LikeNegativeScore (20f);
			CashPositiveScore (20f);
			break;

		case 3:

			nameText.text = characterNameText [3];
			descriptionText.text = charactersText [3];
			LikeNegativeScore (30f);
			CashPositiveScore (10f);
			ViewNegativeScore (30f);
			break;

		case 4:
			nameText.text = characterNameText [4];
			descriptionText.text = charactersText [4];
			CashNegativeScore (20f);
			ViewNegativeScore (30f);
			break;

		case 5:
			nameText.text = characterNameText [5];
			descriptionText.text = charactersText [5];
			CashPositiveScore (20f);
			FollowNegativeScore (30f);
			break;

		case 6:
			nameText.text = characterNameText [6];
			descriptionText.text = charactersText [6];
			LikePositiveScore (30f);
			FollowPositiveScore (20f);
			break;

		case 7:
			nameText.text = characterNameText [7];
			descriptionText.text = charactersText [7];
			ViewNegativeScore (30f);
			CashPositiveScore (20f);
			break;

		case 8:

			nameText.text = characterNameText [8];
			descriptionText.text = charactersText [8];
			ViewPositiveScore (20f);
			LikeNegativeScore (50f);
			break;

		case 9:

			nameText.text = characterNameText [9];
			descriptionText.text = charactersText [9];
			FollowPositiveScore (40f);
			LikePositiveScore (20f);
			break;

		case 10:

			nameText.text = characterNameText [10];
			descriptionText.text = charactersText [10];
			CashPositiveScore (20f);
			LikeNegativeScore (40f);
			break;

		case 11:

			nameText.text = characterNameText [11];
			descriptionText.text = charactersText [11];
			CashNegativeScore (40f);
			ViewPositiveScore (20f);
			break;

		case 12:

			nameText.text = characterNameText [12];
			descriptionText.text = charactersText [12];
			LikeNegativeScore (10f);
			CashPositiveScore (10f);
			ViewNegativeScore (30f);
			break;

		case 13:

			nameText.text = characterNameText [13];
			descriptionText.text = charactersText [13];
			CashPositiveScore (10f);
			LikePositiveScore (30f);
			break;

		case 14:

			nameText.text = characterNameText [14];
			descriptionText.text = charactersText [14];
			CashNegativeScore (40f);
			ViewNegativeScore (40f);
			break;

		case 15:

			nameText.text = characterNameText [15];
			descriptionText.text = charactersText [15];
			FollowNegativeScore (20f);
			CashPositiveScore (20f);

			break;

		case 16:
			nameText.text = characterNameText [16];
			descriptionText.text = charactersText [16];
			LikeNegativeScore (20f);
			FollowPositiveScore (20f);
			break;

		case 17:
			nameText.text = characterNameText [17];
			descriptionText.text = charactersText [17];
			CashNegativeScore (10f);
			ViewPositiveScore (20f);
			FollowPositiveScore (20f);
			break;

		case 18:
			nameText.text = characterNameText [18];
			descriptionText.text = charactersText [18];
			CashNegativeScore (60f);
			LikePositiveScore (60f);
			FollowNegativeScore (60f);
			ViewNegativeScore (60f);
			break;

		case 19:
			
			nameText.text = characterNameText [19];
			descriptionText.text = charactersText [19];
			CashPositiveScore (20f);
			FollowNegativeScore (20f);
			break;

		case 20:

			nameText.text = characterNameText [20];
			descriptionText.text = charactersText [20];
			ViewPositiveScore (20f);
			LikeNegativeScore (20f);
			break;

		case 21:

			nameText.text = characterNameText [21];
			descriptionText.text = charactersText [21];
			LikeNegativeScore (20f);
			CashNegativeScore (10f);
			FollowNegativeScore (30f);
			break;

		case 22:

			nameText.text = characterNameText [22];
			descriptionText.text = charactersText [22];
			FollowPositiveScore (30f);
			ViewNegativeScore (40f);
			break;

		case 23:

			nameText.text = characterNameText [23];
			descriptionText.text = charactersText [23];
			LikeNegativeScore (20f);
			ViewNegativeScore (20f);
			FollowNegativeScore (20f);
			break;

		case 24:
			
			nameText.text = characterNameText [24];
			descriptionText.text = charactersText [24];
			FollowNegativeScore (20f);
			LikeNegativeScore (40f);
			break;

		case 25:

			nameText.text = characterNameText [25];
			descriptionText.text = charactersText [25];
			ViewNegativeScore (30f);
			CashPositiveScore (10f);
			LikeNegativeScore (20f);
			break;

		case 26:

			nameText.text = characterNameText [26];
			descriptionText.text = charactersText [26];
			FollowPositiveScore (20f);
			CashNegativeScore (30f);
			LikeNegativeScore (20f);
			break;

		case 27:

			nameText.text = characterNameText [27];
			descriptionText.text = charactersText [27];
			LikePositiveScore (20f);
			ViewPositiveScore (20f);
			FollowPositiveScore (20f);
			break;

		case 28:

			nameText.text = characterNameText [28];
			descriptionText.text = charactersText [28];
			FollowNegativeScore (20f);
			CashPositiveScore (20f);
			ViewNegativeScore (10f);
			break;

		case 29:
			
			nameText.text = characterNameText [29];
			descriptionText.text = charactersText [29];
			CashPositiveScore (30f);
			LikeNegativeScore (30f);
			ViewNegativeScore (30f);
			break;

		case 30:
			nameText.text = characterNameText [30];
			descriptionText.text = charactersText [30];
			CashPositiveScore (20f);
			LikeNegativeScore (40f);
			break;
		}
	}



	void ChangeCharacter(){

		StartCoroutine (SelectChangeDelay ());
	}



	//--Switch character--//
	IEnumerator SelectChangeDelay(){

		yield return new WaitForSeconds (.2f);
		profileBox.gameObject.transform.DOLocalMoveX (1000f, .25f).SetEase(Ease.InOutBack);
		characterBox.transform.DOPunchScale (new Vector3 (.8f, .8f, 1.0f), 0.65f);
		characterIndex = Random.Range (0, TotalPortrait.Count);
		characterSlot = characterIndex;
		characterBox.sprite = TotalPortrait [characterIndex];
		nameText.text = characterNameText [characterIndex];
		descriptionText.text = charactersText [characterIndex];



		//characterSlot = Random.Range (0, characterPortrait.Length);
		//characterBox.sprite = characterPortrait [characterSlot];
		characterBox.color = new Color (255f, 255f, 255f);



		yield return new WaitForSeconds (.25f);
		profileBox.gameObject.transform.position = new Vector2 (-1000f, profileBox.gameObject.transform.position.y);
		//nameText.text = characterNameText [characterSlot];
		//descriptionText.text = charactersText [characterSlot];


		yield return new WaitForSeconds (.1f);
		profileBox.gameObject.transform.DOLocalMoveX (0f, 1f).SetEase(Ease.InOutBack);
		TotalPortrait.RemoveAt (characterIndex);
		hasSelected = true;
		JB.hasBeenClicked = false;
		JB2.hasBeenClicked = false;
		JB.timer = 5f;
		JB2.timer = 5f;
		JF.hasBeenClicked = false;
		JF.timer = 8f;


	}





	//---Add Function----//


	void LikePositiveScore(float score){

	

		if (score == 200f) 
		{
			likeScore = likeScore + score;
			return;
		}
	
		likeScore = likeScore + score;
		likeMeter.DOValue (likeScore, 1f).SetEase (Ease.InOutElastic);
	}


	void FollowPositiveScore(float score){


		if (score == 200f) 
		{
			followScore = followScore + score;
			return;
		}

		followScore = followScore+ score;
		followMeter.DOValue (followScore, 1f).SetEase (Ease.InOutElastic);


	}


	void CashPositiveScore(float score){



		if (score == 200f) 
		{
			cashScore = cashScore + score;
			return;
		}

		cashScore = cashScore + score;
		cashMeter.DOValue (cashScore, 1f).SetEase (Ease.InOutElastic);
	}


	void ViewPositiveScore(float score){


		if (score == 200f) 
		{
			viewScore = viewScore + score;
			return;
		}

		viewScore = viewScore+ score;
		viewMeter.DOValue (viewScore, 1f).SetEase (Ease.InOutElastic);


	}


	//----Ends Here-----///





	//-----Subtract Functions----//

	void LikeNegativeScore(float score){



		if (score == 0f) 
		{
			likeScore = likeScore - score;
			return;
		}

		likeScore = likeScore - score;
		likeMeter.DOValue (likeScore, 1f).SetEase (Ease.InOutElastic);
	}


	void FollowNegativeScore(float score){


		if (score == 0f) 
		{
			followScore = followScore - score;
			return;
		}

		followScore = followScore - score;
		followMeter.DOValue (followScore, 1f).SetEase (Ease.InOutElastic);


	}


	void CashNegativeScore(float score){



		if (score == 0f) 
		{
			cashScore = cashScore - score;
			return;
		}

		cashScore = cashScore - score;
		cashMeter.DOValue (cashScore, 1f).SetEase (Ease.InOutElastic);
	}


	void ViewNegativeScore(float score){


		if (score == 200f) 
		{
			viewScore = viewScore - score;
			return;
		}

		viewScore = viewScore - score;
		viewMeter.DOValue (viewScore, 1f).SetEase (Ease.InOutElastic);


	}


	//--Ends Here----//







	void GameoverState(){

		hasGameOver = true;
		Gameover.gameObject.transform.DOLocalMoveY (0f, 1f).SetEase (Ease.InOutBack);
	}


	public 	void RestartReset(){

		StartCoroutine (ResetState ());
		GUIButton [2].transform.DOPunchScale (new Vector3 (.8f, .8f, 1.0f), 0.2f).SetEase (Ease.InOutQuad);

	}

	IEnumerator ResetState(){

		yield return new WaitForSeconds (.1f);
		likeScore = 100f;
		followScore = 100f;
		cashScore = 100f;
		viewScore = 100f;
		likeMeter.value = likeScore;
		followMeter.value = followScore;
		cashMeter.value = cashScore;
		viewMeter.value = viewScore;

		characterBox.sprite = characterPortrait [0];
		nameText.text = characterNameText [0];
		descriptionText.text = charactersText [0];
		profileBox.gameObject.transform.position = new Vector2 (-1000f, profileBox.gameObject.transform.position.y);
		yield return new WaitForSeconds (.5f);

		Gameover.gameObject.transform.DOLocalMoveY (1400f, .8f).SetEase (Ease.InBounce);

		yield return new WaitForSeconds (.5f);
		profileBox.gameObject.transform.DOLocalMoveX (0f, 1f).SetEase(Ease.InOutBack);
		hasGameOver = false;

	}




	}



