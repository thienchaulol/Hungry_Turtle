using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play_again : MonoBehaviour {

    public game_manager game_manager_var;
    public object_pool_control object_pool_control_var;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void play_again_button()
    {
        game_manager_var.score = 0;
        game_manager_var.totalMissedFood = 0;
        game_manager_var.gameOverButtons.SetActive(false);
        game_manager_var.timeScale1();
        //TODO: Refresh all food clones.
        for(int i = 0; i < object_pool_control_var.theObjectPool.pooledObjects.Count; i++) //Genius for figuring out how to travel to Refresh() call.
        {
            object_pool_control_var.theObjectPool.pooledObjects[i].GetComponent<sprite_control>().Refresh(); //Or idiot for creating too many scripts.
        }

    }
}
