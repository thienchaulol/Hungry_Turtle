using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class object_pool_control : MonoBehaviour {

    public float spawnTime; //spawnTime will decrease with score. (Game will speed up)
    public sprite_control sprite;
    public object_pooler theObjectPool;

    // Use this for initialization
    void Start () {
        //Pull an object every "spawnTime" seconds.
        InvokeRepeating("spawnInterval", 0, spawnTime);
    }
	
	// Update is called once per frame
	void Update () {

	}

    void spawnInterval()
    {
        if (!sprite.gameObject.activeSelf)
        {
            sprite.gameObject.SetActive(true);
        }
        else
        {
            GameObject newObject = theObjectPool.GetPooledObject();
            newObject.SetActive(true);
        }
    }
}
