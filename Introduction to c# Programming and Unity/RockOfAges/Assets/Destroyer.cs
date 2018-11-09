using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    [SerializeField]
    GameObject prefabExplosion;

    Timer explodeTimer;

    private void Start()
    {
        explodeTimer = gameObject.AddComponent<Timer>();
        explodeTimer.Duration = 1;
        explodeTimer.Run();
    }

    // Update is called once per frame
    void Update () {
        if(explodeTimer.Finished)
        {
            explodeTimer.Run();
            GameObject rock = GameObject.FindWithTag("C4Rock");
            if (rock != null)
            {
                Instantiate<GameObject>(prefabExplosion, rock.transform.position, Quaternion.identity);
                Destroy(rock);
            }

        }
    }
}
