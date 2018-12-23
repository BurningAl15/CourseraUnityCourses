using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Lets game object shoot based on keyboard input
/// </summary>
public class Shooter : MonoBehaviour
{
    [SerializeField]
    GameObject prefabBullet;

    // shooting support
    Timer cooldownTimer;
    bool canShoot = true;
    public float duration;
	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
        // initialize cooldown timer
        duration=ConfigurationUtils.CooldownSeconds;
        cooldownTimer = gameObject.AddComponent<Timer>();
        cooldownTimer.Duration = ConfigurationUtils.CooldownSeconds;
	}
	
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		// check for setting can shoot flag
        if (!canShoot && 
            cooldownTimer.Finished)
        {
            canShoot = true;
        }

        // check for shooting input
        if (canShoot &&
            Input.GetAxis("Fire1") > 0)
        {
            // start cooldown
            canShoot = false;
            cooldownTimer.Run();

            // shoot bullet
            Instantiate(prefabBullet, transform.position,
                Quaternion.identity);
        }
	}
}
