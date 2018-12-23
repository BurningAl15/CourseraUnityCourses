using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {

    const float BounceAngleHalfRange=Mathf.Deg2Rad*60;
    const float tolerance=0.05f;

    float halfColliderWidth;
    float halfColliderHeight;

    Rigidbody2D rgb;

    float halfSize;
    Vector2 move;
	void Start () {
		halfColliderWidth=GetComponent<BoxCollider2D>().size.x/2;
        halfSize=transform.localScale.x/2f;
        halfColliderHeight=GetComponent<BoxCollider2D>().size.y/2;
        //This is more efficient than call getcomponent everytime
        rgb=GetComponent<Rigidbody2D>();
	}
	
    /// <summary>
    /// Is called 50 times per second
    /// Its the most appropiated place to move the game object
    /// </summary>
	void FixedUpdate () {
        Move();
	}

    void Move()
    {
        move=new Vector2(Input.GetAxis("Horizontal")*ConfigurationUtils.PaddleMoveUnitsPerSecond,this.transform.position.y);
        rgb.MovePosition(CalculateClampedX(move.x));
    }

    Vector2 CalculateClampedX(float xPosition)
    {
        Vector2 pos = new Vector2(Mathf.Clamp(xPosition, ScreenUtils.ScreenLeft + halfSize, ScreenUtils.ScreenRight - halfSize), this.transform.position.y);

        return pos;
    }

    bool isColliding(Collision2D col)
    {
        if(col.transform.position.y>this.transform.position.y+halfColliderHeight+tolerance)
            return true;
        else
            return false;
    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball") && isColliding(coll))
        {
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                halfColliderWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
      
            // tell ball to set direction to new direction
            BallBehaviour ballScript = coll.gameObject.GetComponent<BallBehaviour>();
            ballScript.SetDirection(direction);
        }
    }
}
