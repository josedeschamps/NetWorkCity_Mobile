using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameOverState : MonoBehaviour {

	public SFXControl sfxControl;

	public Animator fader;
	public string sceneName;
	public GameObject optionPanel;
	public GameObject replayButton;
	public GameObject optionButton;


	private void Start(){

		DOTween.Init ();
	}



	public void ReplayButton(){
		StartCoroutine (FadeOutScene ());

	
	}

	IEnumerator FadeOutScene(){
		
		sfxControl.sfxSounds [0].Play ();
		replayButton.transform.DOPunchScale (new Vector3 (1.1f, 1.1f, 1f), .25f, 2, 1f).SetEase (Ease.OutQuad);
		yield return new WaitForSeconds (.1f);
		transform.DOLocalMoveY (1000, 1.5f).SetEase (Ease.InElastic);
		yield return new WaitForSeconds (1.5f);
		sfxControl.sfxSounds [8].Play ();
		fader.SetBool ("SetFader", true);

		yield return new WaitForSeconds (1f);
		SceneManager.LoadScene (sceneName);
	}



	public void OptionButton(){
		
		sfxControl.sfxSounds [0].Play ();
		StartCoroutine (LoadOptionMenu ());

	}

	IEnumerator LoadOptionMenu(){


		optionButton.transform.DOPunchScale (new Vector3 (1.1f, 1.1f, 1f), .25f, 2, 1f).SetEase (Ease.OutQuad);

		yield return new WaitForSeconds (.1f);
		sfxControl.sfxSounds [3].Play ();
		optionPanel.transform.DOLocalMoveX (0f, 1f).SetEase (Ease.InOutBack);
		NewGameManager.IsMenuOpen = true;

	}


}
