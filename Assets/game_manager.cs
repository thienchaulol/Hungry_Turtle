using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_manager : MonoBehaviour {

    bool paused = false;

	void Update () {
		
	}

    public void play_button()
    {
        SceneManager.LoadScene("In_Game", LoadSceneMode.Single);
    }

    public void reward_button()
    {
        SceneManager.LoadScene("Rewards", LoadSceneMode.Single);
    }

    public void menu_button()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void pause_button()
    {
        //If paused is true, pause the game.
        paused = !paused;
        Debug.Log(paused);
    }
}
