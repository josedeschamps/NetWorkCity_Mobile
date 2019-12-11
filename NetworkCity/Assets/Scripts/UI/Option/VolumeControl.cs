using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour {

	private float audioVol = 0.1f;
	public Slider volSlider;
	private AudioSource gameSound;





	void Start () {


		gameSound = GetComponent<AudioSource> ();

		int hasPlayedMusic = PlayerPrefs.GetInt( "HasPlayedMusic");

		if( hasPlayedMusic == 0 )
		{

			audioVol = 0.1f;
			gameSound.volume = audioVol;
			volSlider.value = audioVol;
			PlayerPrefs.SetFloat ("CurVol", audioVol);
			PlayerPrefs.SetInt( "HasPlayedMusic", 1 );
		}
		else
		{

			audioVol = PlayerPrefs.GetFloat ("CurVol");
			volSlider.value = audioVol;
		}
	

	}




	public void VolController(){
		gameSound.volume = audioVol;
		audioVol = volSlider.value;
		PlayerPrefs.SetFloat ("CurVol", audioVol);



	}


}
