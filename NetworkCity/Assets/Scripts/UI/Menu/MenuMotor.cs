using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MenuMotor : MonoBehaviour {

	public string sceneName;
	public Animator fader;
	public GameObject optionMusic;
	public GameObject playButton;
	public GameObject optionButton;
	public GameObject backButton;
	public SFXControl sfXControl;



	void Start(){

		DOTween.Init ();

	}



	public void LoadPlayScene(){

	

		PlayerPrefs.Save ();
		sfXControl.sfxSounds [0].Play ();
		StartCoroutine (LoadScene ());

	}

	IEnumerator LoadScene(){
		
		playButton.transform.DOPunchScale (new Vector3 (1.1f, 1.1f, 1f), .25f, 2, 1f).SetEase (Ease.OutQuad);
		yield return new WaitForSeconds (.3f);
		fader.SetBool ("SetFader", true);


		yield return new WaitForSeconds (.2f);

		SceneManager.LoadScene (sceneName);

	}


	public void OptionButton(){
		sfXControl.sfxSounds [0].Play ();
		StartCoroutine (LoadOptionMenu ());

	}

	IEnumerator LoadOptionMenu(){

		optionButton.transform.DOPunchScale (new Vector3 (1.1f, 1.1f, 1f), .25f, 2, 1f).SetEase (Ease.OutQuad);

		yield return new WaitForSeconds (.1f);
		sfXControl.sfxSounds [3].Play ();
		optionMusic.transform.DOLocalMoveX (0f, 1f).SetEase (Ease.InOutBack);
		NewGameManager.IsMenuOpen = true;

	}

	public void BackButton(){
		sfXControl.sfxSounds [0].Play ();
		StartCoroutine (ReturnBackToMain ());
	}

	IEnumerator ReturnBackToMain(){

		backButton.transform.DOPunchScale (new Vector3 (1.1f, 1.1f, 1f), .25f, 2, 1f).SetEase (Ease.OutQuad);
		yield return new WaitForSeconds (.1f);
		sfXControl.sfxSounds [3].Play ();
		optionMusic.transform.DOLocalMoveX (-800f, 1f).SetEase (Ease.InOutBack);
		yield return new WaitForSeconds (1f);
		optionMusic.transform.position = new Vector2 (2400, optionMusic.transform.position.y);
		NewGameManager.IsMenuOpen = false;

	}

}
