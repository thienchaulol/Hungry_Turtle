using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_manager : MonoBehaviour {

    public bool paused = false;
    public static int score;
    public UnityEngine.UI.Image pause_image;

    void Start()
    {
        pause_image.enabled = false;
    }

	void Update () {
		
	}

    public void pause_button()
    {
        if(paused == false)
        {
            paused = true;
            pause_image.enabled = true;
            Time.timeScale = 0;
        }
        else if(paused == true)
        {
            paused = false;
            pause_image.enabled = false;
            Time.timeScale = 1;
        }
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
}
