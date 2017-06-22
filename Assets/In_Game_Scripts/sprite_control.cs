using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprite_control : MonoBehaviour {

    public float fallSpeed;
    public float sinkSpeed;
    public float expirationTime;
    bool sinking = false;
    bool expired = false;
    public Transform floatingPoint;

    void OnEnable()
    {
        //The food will appear in a puff of smoke above the water and fall
    }

    void Update()
    {
        if (gameObject.transform.position.y > floatingPoint.position.y)
        {
            Movement();
        }
        if (gameObject.transform.position.y <= floatingPoint.position.y && !sinking)
        {
            //Give the sprite a "floating" animation for 3 seconds
            //After 3 seconds, the sprite will beging to sink
            StartCoroutine(waitThreeSeconds());
        }
        if (sinking && !expired)
        {
            transform.Translate(Vector2.down * sinkSpeed * Time.deltaTime);
            //After X amount of time, have the food expire and make the tank dirty
            StartCoroutine(waitXSeconds(expirationTime));
        }
    }

    void Movement()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    IEnumerator waitThreeSeconds()
    {
        yield return new WaitForSeconds(3);
        sinking = true;
    }

    IEnumerator waitXSeconds(float X)
    {
        yield return new WaitForSeconds(X);
        expired = true;
        sinking = false;
    }
}
