using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour {

    Rigidbody2D rgb;

	void Start () {
        rgb=GetComponent<Rigidbody2D>();
        //transform.Rotate(new Vector3(20f,0,0));
        transform.rotation=Quaternion.Euler(20f,0,0);        
	    rgb.AddForce(Vector2.one*ConfigurationUtils.BallImpulseForce);
    }
	
	void Update () {
		
	}

    public void SetDirection(Vector2 direction)
    {
        direction= rgb.velocity.magnitude* rgb.velocity;
    }
}
