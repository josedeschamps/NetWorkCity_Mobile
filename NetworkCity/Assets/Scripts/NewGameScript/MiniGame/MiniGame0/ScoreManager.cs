using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {


	public int score;
	public int bestScore;
	public Text textScore;
	public Text textBestScore;

	void Start () {

		score = 0;
		textScore.text = "" + score;
		textBestScore.text = "" + PlayerPrefs.GetInt ("HighScore");
		bestScore = PlayerPrefs.GetInt ("HighScore");
		
	}
	

	void Update () {



		if (score > bestScore) {
			
			bestScore = score;
			PlayerPrefs.SetInt ("HighScore", bestScore);
		}
		
	}

	public void AddScore(int add){

		score = score + add;
		textScore.text = "" + score;



	}


	public void SaveScore(){

		PlayerPrefs.Save ();
	}
}
