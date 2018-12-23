using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehaviour : MonoBehaviour {
    Rigidbody2D rgb;

    bool rotate;
    float rotationValue;

    float[] val=new float[2];

	void Start () {
		rgb=GetComponent<Rigidbody2D>();
        val[0]=-1;
        val[1]=1;
        rotationValue=Random.Range(120,250);
        rotationValue=val[Random.Range(0,2)]* rotationValue;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Ball"))
        {
            //V1
            //Destroy(this.gameObject);
            
            //V2
            StartCoroutine("Physic");
        }
    }

    private void FixedUpdate()
    {
        if(rotate)
            transform.Rotate(new Vector3(0,0,rotationValue*Time.deltaTime));
    }

    IEnumerator Physic()
    {
        rgb.bodyType=RigidbodyType2D.Dynamic;
        GetComponent<Collider2D>().enabled=false;
        rotate=true;
        yield return null;
        rgb.AddForce(Vector2.up*Random.Range(1f,3f),ForceMode2D.Impulse);
        yield return new WaitForSeconds(.2f);
        rgb.AddForce(Vector2.down*Random.Range(4.5f,6f),ForceMode2D.Impulse);
        StopCoroutine("Physic");
    }
}
