using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class BasicMenuMotor : MonoBehaviour {

	public string sceneName;
	public Animator fader;
	public GameObject playButton;
	private AudioSource sound;



	void Start(){

		DOTween.Init ();
		sound = GetComponent<AudioSource> ();

	}



	public void LoadPlayScene(){



		PlayerPrefs.Save ();
		sound.Play ();
		StartCoroutine (LoadScene ());

	}

	IEnumerator LoadScene(){

		playButton.transform.DOPunchScale (new Vector3 (1.1f, 1.1f, 1f), .25f, 2, 1f).SetEase (Ease.OutQuad);
		yield return new WaitForSeconds (.3f);
		fader.SetBool ("SetFader", true);


		yield return new WaitForSeconds (.2f);

		SceneManager.LoadScene (sceneName);

	}


}