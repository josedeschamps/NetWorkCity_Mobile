using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuGameMotor : MonoBehaviour {


	public GameObject optionPanel;
	public GameObject optionButton;
	public GameObject backButton;
	public GameObject homeButton;
	public SFXControl sfXControl;
	public string sceneName;
	public Animator fader;



	void Start(){

		DOTween.Init ();

	}




	public void LoadPlayScene(){



		PlayerPrefs.Save ();
		sfXControl.sfxSounds [0].Play ();
		StartCoroutine (LoadScene ());

	}

	IEnumerator LoadScene(){

		homeButton.transform.DOPunchScale (new Vector3 (1.1f, 1.1f, 1f), .25f, 2, 1f).SetEase (Ease.OutQuad);
		yield return new WaitForSeconds (.3f);
		fader.SetBool ("SetFader", true);


		yield return new WaitForSeconds (.5f);

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
		optionPanel.transform.DOLocalMoveX (0f, 1f).SetEase (Ease.InOutBack);
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
		optionPanel.transform.DOLocalMoveX (-800f, 1f).SetEase (Ease.InOutBack);
		yield return new WaitForSeconds (1f);
		optionPanel.transform.position = new Vector2 (2400, optionPanel.transform.position.y);
		NewGameManager.IsMenuOpen = false;

	}

}


