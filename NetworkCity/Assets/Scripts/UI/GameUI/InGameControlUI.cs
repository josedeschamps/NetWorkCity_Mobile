using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class InGameControlUI : MonoBehaviour {

	public string sceneName;
	public GameObject optionMenu;
	public Animator fader;




		void Start(){
			DOTween.Init ();
		}


	public void LoadMainMenu(){

		fader.SetBool ("SetFader", true);
		PlayerPrefs.Save ();
		StartCoroutine (LoadScene ());

	}

	IEnumerator LoadScene(){

		yield return new WaitForSeconds (.2f);

		SceneManager.LoadScene (sceneName);

	}
		

		public void OptionButton(){

			optionMenu.transform.DOLocalMoveY (0f, 1f).SetEase (Ease.InOutBack);

		}

		public void BackButton(){

			optionMenu.transform.DOLocalMoveY (-1330f, 1f).SetEase (Ease.InOutBack);
		}



	}

