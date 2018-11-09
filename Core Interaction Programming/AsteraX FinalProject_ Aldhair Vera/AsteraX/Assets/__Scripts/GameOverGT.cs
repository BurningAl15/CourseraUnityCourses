using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverGT : MonoBehaviour {

    static private GameOverGT   _instance;
    static public GameOverGT    instance
	{
		get
		{
			if(_instance == null)
				_instance = GameOverGT.FindObjectOfType<GameOverGT>();
			return _instance;
		}
	}

	[SerializeField]
	GameObject GameOverUI;
	[SerializeField]
	Text finalLevel;
	[SerializeField]
	Text finalScore;
	
	public void SetFinalData(int _level,int _score)
	{
		finalLevel.text="Final Level: "+_level;
		finalScore.text="Final Score: "+_score;
	}

	public void CallGameOverScreen()
	{
		GameOverUI.SetActive(true);
	}
}
