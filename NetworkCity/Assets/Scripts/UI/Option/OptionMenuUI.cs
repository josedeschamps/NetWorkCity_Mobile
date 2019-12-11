using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenuUI : MonoBehaviour {

	public float audioVol;
	public float sfxVol;
	public Slider volSlider;
	public Slider sfxSlider;
	private AudioSource gameSound;


	void Start () {

		gameSound = GetComponent<AudioSource> ();
		audioVol = PlayerPrefs.GetFloat ("CurVol");
		volSlider.value = audioVol;
		
	}
	
	// Update is called once per frame
	void Update () {


		
	}

	public void VolumeControl(){

		gameSound.volume = audioVol;
		audioVol = volSlider.value;
		PlayerPrefs.SetFloat ("CurVol", audioVol);


	}


}
