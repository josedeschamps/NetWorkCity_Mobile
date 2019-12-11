using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PageUIMotor : MonoBehaviour {

	public Image storyImage;
	public Sprite[] storyBoardPages;
	public int storyPos = 0;


	void Start(){

		DOTween.Init ();
		storyImage.sprite = storyBoardPages [storyPos];

	}


	public void NextPage(){


		if (storyPos < storyBoardPages.Length-1) {

			storyPos++;
		
		} else {

			storyPos = 0;
		}

		storyImage.sprite = storyBoardPages [storyPos];

	}


	public void PreviousPage(){


		if (storyPos <= storyBoardPages.Length - 1) {

			if (storyPos == 0) 
			{
				storyPos = 0;

			} 

			else 
			{
				storyPos--;
			}
		} 

		else 
		{

			storyPos = 0;
		}

		storyImage.sprite = storyBoardPages [storyPos];

	}

	}


