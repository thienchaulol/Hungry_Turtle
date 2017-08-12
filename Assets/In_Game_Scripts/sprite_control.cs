using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sprite_control : MonoBehaviour {

    public game_manager game_manager;
    public UnityEngine.UI.Image turtle;
    public Transform floatingPoint;
    private Vector2 initialPos;
    private Vector3 initialTurtlePos;
    
    public float fallSpeed;
    public float timeBeforeSink;
    public float sinkSpeed;
    public float expirationTimeInWater;
    public float ceilingVal; //height to drop food from
    public float turtleSpeed;
    bool sinking = false;
    bool expired = false;
    public bool eatFood = false;

    void Awake()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
    }

    void Start()
    {
        //Record initial position to reset after expiration
        initialPos = new Vector2(Random.Range(-2f, 2f), ceilingVal); //set initial(random) position of game object
        gameObject.transform.position = initialPos; //store initial position of game object
        //TODO(Animation): The food will appear in a puff of smoke above the water and fall
        initialTurtlePos = turtle.transform.position;
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
        if ((gameObject.transform.position.y <= floatingPoint.position.y) && eatFood)
        {
            //TODO: BUG: If the turtle is travelling to a clone before the clone disappears the turtle will travel to the same clone when it reappears
            turtle.transform.position = Vector2.MoveTowards(turtle.transform.position, gameObject.transform.position, turtleSpeed * Time.deltaTime);
            if (turtle.transform.position == gameObject.transform.position)
            {
                game_manager.score++;
                eatFood = false;
                Refresh();
                //TODO: Return turtle to original position after consuming food
                //turtle.transform.position = Vector2.MoveTowards(turtle.transform.position, initialTurtlePos, turtleSpeed * Time.deltaTime);
            }
            if (!gameObject.activeSelf)
            {
                eatFood = false;
                Refresh();
            }
        }
    }

    void Movement()
    {
        expired = false;
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    IEnumerator waitYSeconds(float Y)
    {
        yield return new WaitForSeconds(Y);
        sinking = true;
    }

    IEnumerator waitXSeconds(float X)
    {
        yield return new WaitForSeconds(X);
        game_manager.missedFood();
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
            eatFood = true;
        }
    }
}
