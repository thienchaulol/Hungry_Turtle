using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprite_control : MonoBehaviour {

    public float fallSpeed;
    public float sinkSpeed;
    public float expirationTime;
    public float ceilingVal; //height to drop food from
    bool sinking = false;
    bool expired;
    public Transform floatingPoint;
    private Vector2 initialPos;

    void Start()
    {
        //Record initial position to reset after expiration
        initialPos = new Vector2(Random.Range(-2f, 2f), ceilingVal);    //set initial(random) position of game object
        gameObject.transform.position = initialPos; //store initial position of game object
        //TODO: The food will appear in a puff of smoke above the water and fall
    }

    void Update()
    {
        if (gameObject.transform.position.y > floatingPoint.position.y)
        {
            Movement();
        }
        if (gameObject.transform.position.y <= floatingPoint.position.y && !sinking)
        {
            //TODO: Give the sprite a "floating" animation for 3 seconds
            StartCoroutine(waitThreeSeconds()); //After 3 seconds, the sprite will beging to sink
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
        Refresh();
        //TODO: Food will crumble before it disappears
    }

    void Refresh()
    {
        expired = true;
        initialPos = new Vector2(Random.Range(-2f, 2f), ceilingVal); //set new random initial position
        transform.position = initialPos;	//set new random position
        sinking = false;
        gameObject.SetActive(false);
    }
}
