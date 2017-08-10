using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprite_control : MonoBehaviour {

    public game_manager game_manager;
    public Transform floatingPoint;
    private Vector2 initialPos;
    
    public float fallSpeed;
    public float timeBeforeSink;
    public float sinkSpeed;
    public float expirationTimeInWater;
    public float ceilingVal; //height to drop food from
    bool sinking = false;
    bool expired = false;

    void Start()
    {
        //Record initial position to reset after expiration
        initialPos = new Vector2(Random.Range(-2f, 2f), ceilingVal); //set initial(random) position of game object
        gameObject.transform.position = initialPos; //store initial position of game object
        //TODO(Animation): The food will appear in a puff of smoke above the water and fall
    }

    void Update()
    {
        if (gameObject.transform.position.y > floatingPoint.position.y)
        {
            Movement();
        }
        if ((gameObject.transform.position.y <= floatingPoint.position.y) && !sinking)
        {
            //TODO(Animation): Give the sprite a "floating" animation for Z seconds
            StartCoroutine(waitYSeconds(timeBeforeSink)); //After Y seconds, the sprite will begin to sink
        }
        if (sinking && !expired)
        {
            transform.Translate(Vector2.down * sinkSpeed * Time.deltaTime);
            //TODO(Animation): After X amount of time, have the food expire and make the tank dirty
            StartCoroutine(waitXSeconds(expirationTimeInWater));
        }
    }

    void Movement()
    {
        expired = false;
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    IEnumerator waitYSeconds(float y)
    {
        yield return new WaitForSeconds(y);
        sinking = true;
    }

    IEnumerator waitXSeconds(float X)
    {
        yield return new WaitForSeconds(X);
        Refresh();
        //TODO(Animation): Food will crumble before it disappears
    }

    void Refresh()
    {
        initialPos = new Vector2(Random.Range(-2f, 2f), ceilingVal); //set new random initial position
        transform.position = initialPos;	//set new random position
        sinking = false;
        expired = true;
        gameObject.SetActive(false);
    }

    void OnMouseDown()
    {
        if(game_manager.paused == false && !(gameObject.transform.position.y > floatingPoint.position.y))
        {
            game_manager.score++;
            Refresh();
        }
    }
}
