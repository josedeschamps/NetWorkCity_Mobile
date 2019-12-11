using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXControl : MonoBehaviour {

	private float audioSFXVol = 1f;
	public Slider sfxSlider;
	public AudioSource[] sfxSounds;





	void Start () {

		int hasPlayedSFX = PlayerPrefs.GetInt( "HasPlayedSFX");

		if( hasPlayedSFX == 0 )
		{
			audioSFXVol = 1f;
			for (int i = 0; i < sfxSounds.Length; i++) {

		
				sfxSounds [i].volume = audioSFXVol;

			}
			PlayerPrefs.SetInt( "HasPlayedSFX", 1 );
			PlayerPrefs.SetFloat ("CurSFXVol", audioSFXVol);
			sfxSlider.value = audioSFXVol;
		}
		else
		{
			audioSFXVol = PlayerPrefs.GetFloat ("CurSFXVol");
			sfxSlider.value = audioSFXVol;

		}

			


	

	}


	void Update(){

		if (Input.GetKeyDown (KeyCode.Space)) {

			PlayerPrefs.DeleteAll ();
		}

	}





	public void VolController(){

	
		for (int i = 0; i < sfxSounds.Length; i++) {

			sfxSounds [i].volume = audioSFXVol;

		}

		audioSFXVol = sfxSlider.value;
		PlayerPrefs.SetFloat ("CurSFXVol", audioSFXVol);



	}
}
