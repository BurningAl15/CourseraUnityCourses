using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {
    //Here we declare the class
    Rigidbody2D rgb;

    Vector2 thrustDirection;
    const float ThrustForce = 5;

    float radius;

    [SerializeField]
    float rotateDegreesPerSecond;

    // Use this for initialization
    void Start () {
        rgb = GetComponent<Rigidbody2D>();
        thrustDirection = new Vector2(1, 0);
        radius = gameObject.GetComponent<CircleCollider2D>().radius;
    }

    // This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    void FixedUpdate () {
        if(Input.GetAxis("Thrust")!=0)
        {
            rgb.AddForce(ThrustForce * thrustDirection, ForceMode2D.Force);
        }
        RotateDegreesPerSecond();
    }

    void RotateDegreesPerSecond()
    {
        float rotateInput = Input.GetAxis("Rotate");
        float rotationAmount = rotateDegreesPerSecond * Time.deltaTime;
        
        if (rotateInput < 0)
        {
            rotationAmount *= -1;
        }

        transform.Rotate(Vector3.forward,rotationAmount);
        Debug.Log(rotateInput);
        thrustDirection = new Vector2(Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad), Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad));
    }

    //Disables the behaviour when it is invisible
    private void OnBecameInvisible()
    {
        if (transform.position.x >= ScreenUtils.ScreenRight)
            transform.position = new Vector2(ScreenUtils.ScreenLeft, transform.position.y);
        else if (transform.position.x <= ScreenUtils.ScreenLeft)
            transform.position = new Vector2(ScreenUtils.ScreenRight, transform.position.y);
        else if (transform.position.y >= ScreenUtils.ScreenTop)
            transform.position = new Vector2(transform.position.y, ScreenUtils.ScreenBottom);
        else if (transform.position.y <= ScreenUtils.ScreenBottom)
            transform.position = new Vector2(transform.position.y, ScreenUtils.ScreenTop);
    }
}
