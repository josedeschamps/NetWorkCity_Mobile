using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class NewGameManager : MonoBehaviour {

	public SFXControl sfxControl;

	public Image teamPortrait;
	public Sprite[] teamUnlock1Image;
	public Sprite[] teamUnlock2Image;
	public Sprite[] teamUnlockAllImage;

	public Animator fader;
	public GameObject playButton;
	private int teamPos_Slot = 0;
	public SwipeControl swipeControl;
	public bool startTeam,team1,team2,teamAll = false;
	private bool hasReachEnd = false;
	public static bool IsMenuOpen = false;

	public float faderTime;
	public float sceneTime;


	void Start () {

		DOTween.Init ();
		teamPortrait.sprite = teamUnlockAllImage [teamPos_Slot];

	}




	void Update(){

		if (swipeControl.SwipeRight && !IsMenuOpen ) {

			sfxControl.sfxSounds [1].Play ();
			LoadNextTeam ();
		}

		if (swipeControl.SwipeLeft && !IsMenuOpen) {


			LoadPreviousTeam ();

			if (!hasReachEnd) {
				
				sfxControl.sfxSounds [1].Play ();
			} else {

				hasReachEnd = false;
			}
		}


		if (swipeControl.Tap) {

			Debug.Log ("Tap");
		}
	}
	//This is the scrolling for the team selections
	public void LoadNextTeam(){


		DoNextMoveAnimation ();



	}


	public void LoadPreviousTeam(){

		DoPreviousMoveAnimation ();
	}

	//This loads the specifc team
	public void LoadSelectedTeam(){

		switch (teamPos_Slot) {

		case 0:
				LoadingScene (2);
			break;

		case 1:
			if (team1 || teamAll) {
				LoadingScene (3);
			}
			break;

		case 2:
			if (team2 || teamAll) {
				LoadingScene (4);
			}
			break;

		}
	}


	//this is selecting the right scene for the team.
	void LoadingScene(int num){
		sfxControl.sfxSounds [0].Play ();
		playButton.transform.DOPunchScale (new Vector3 (1.1f, 1.1f, 1f), .25f, 2, 1f).SetEase (Ease.OutQuad);
		StartCoroutine (LoadingTeam (num));

	}

	IEnumerator LoadingTeam(int teamSceneNum){


		yield return new WaitForSeconds (faderTime);
		fader.SetBool ("SetFader", true);
		yield return new WaitForSeconds (sceneTime);
		SceneManager.LoadScene (teamSceneNum);

	}



	private void DoNextMoveAnimation(){

		StartCoroutine (NextAnim ());
	}

	IEnumerator NextAnim(){

		teamPortrait.gameObject.transform.DOLocalMoveX (800, .25f).SetEase (Ease.InQuad);
		yield return new WaitForSeconds (.5f);
		teamPortrait.gameObject.transform.localPosition = new Vector2 (-800, 20);
		yield return new WaitForSeconds (.25f);
		teamPortrait.gameObject.transform.DOLocalMoveX (0, .8f).SetEase (Ease.InOutBack);

		if (teamPos_Slot < teamUnlockAllImage.Length-1) {
			teamPos_Slot++;
		} else {

			teamPos_Slot = 0;
		}


		if (startTeam) {

			teamPortrait.sprite = teamUnlock1Image [teamPos_Slot];
		}

		if (team1) {

			teamPortrait.sprite = teamUnlock2Image [teamPos_Slot];
		}

		if (team2) {

			teamPortrait.sprite = teamUnlockAllImage [teamPos_Slot];
		}


	}



	private void DoPreviousMoveAnimation(){

		StartCoroutine (PreviousAnim ());
	}

	IEnumerator PreviousAnim(){

	

		if (teamPos_Slot <= teamUnlockAllImage.Length - 1) {

			if (teamPos_Slot == 0) 
			{
				hasReachEnd = true;
				teamPos_Slot = 0;
				teamPortrait.gameObject.transform.DOPunchScale (new Vector3 (1.05f, 1.05f, 1.05f), .5f, 10, 1f).SetEase (Ease.OutBounce);
				sfxControl.sfxSounds [2].Play ();
			} 

			else 
			{
				teamPos_Slot--;
				teamPortrait.gameObject.transform.DOLocalMoveX (-800, .25f).SetEase (Ease.InQuad);
				yield return new WaitForSeconds (.5f);
				teamPortrait.gameObject.transform.localPosition = new Vector2 (800, 20);
				yield return new WaitForSeconds (.25f);
				teamPortrait.gameObject.transform.DOLocalMoveX (0, .8f).SetEase (Ease.InOutBack);

			}
		} 

		else 
		{

			teamPos_Slot = 0;
		}

		if (startTeam) {

			teamPortrait.sprite = teamUnlock1Image [teamPos_Slot];
		}

		if (team1) {

			teamPortrait.sprite = teamUnlock2Image [teamPos_Slot];
		}

		if (team2) {

			teamPortrait.sprite = teamUnlockAllImage [teamPos_Slot];
		}
			

	}



}
