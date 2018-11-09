using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpsGT : MonoBehaviour {

    static private JumpsGT   _instance;
    static public JumpsGT    instance
	{
		get
		{
			if(_instance == null)
				_instance = JumpsGT.FindObjectOfType<JumpsGT>();
			return _instance;
		}
	}

	[SerializeField]
	Text jumpText;

	[SerializeField]
	int maxJumps;
	int currentJumps;
	void Start () {
		currentJumps=maxJumps;
		jumpText.text=""+currentJumps;
	}
	
	void Update () {
		
	}

	public void UseJumps()
	{
		if(currentJumps>0)
			currentJumps--;

		jumpText.text=""+currentJumps;
	}
	
	public int JumpsLeft()
	{
		return currentJumps;
	}

}
