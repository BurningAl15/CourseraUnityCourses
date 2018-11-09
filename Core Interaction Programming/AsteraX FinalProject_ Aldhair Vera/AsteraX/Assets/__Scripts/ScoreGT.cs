using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGT : MonoBehaviour {

    static private ScoreGT   _instance;
    static public ScoreGT    instance
	{
		get
		{
			if(_instance == null)
				_instance = ScoreGT.FindObjectOfType<ScoreGT>();
			return _instance;
		}
	}

	[SerializeField]
	Text scoreText;

	public int score;

	void Start () {
		scoreText.text=""+score;
	}
	
	void Update () {
		
	}

	public void AddPoints(int points)
	{
		score+=points;
		scoreText.text=""+score;
	}
}
