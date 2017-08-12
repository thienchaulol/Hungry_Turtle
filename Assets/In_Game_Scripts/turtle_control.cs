using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtle_control : MonoBehaviour {

    public sprite_control food;
    public UnityEngine.UI.Image turtle;
    private Vector2 initialTurtlePos;
    public float turtleSpeed;

    // Use this for initialization
    void Start ()
    {
        initialTurtlePos = turtle.transform.position;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (food.eatFood)
        {
            transform.position = Vector2.MoveTowards(turtle.transform.position, gameObject.transform.position, turtleSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(turtle.transform.position, initialTurtlePos, turtleSpeed * Time.deltaTime);
        }
	}
}
