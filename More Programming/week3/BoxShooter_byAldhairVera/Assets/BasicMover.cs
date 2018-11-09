using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMover : MonoBehaviour {
    public float spinSpeed=180.0f;
    public float motionMagnitude=0.1f;

    public bool doSpin=true;
    public bool doMotion=false;

	// Update is called once per frame
	void Update () {
        //Rotate in a determinated time (time.deltatime)
        if(doSpin)
            transform.Rotate(Vector3.up*spinSpeed*Time.deltaTime);
	    if(doMotion)
            transform.Translate(Vector3.up*Mathf.Sin(Time.timeSinceLevelLoad)*motionMagnitude);
    }
}
