using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_manager : MonoBehaviour {

    public int score;
    public static int totalScore;
    public int totalMissedFood;

    //At score 25, 50, 100, 200, 400, ..., have the fallSpeed, sinkSpeed increase by 25% and timeBeforeSink, expirationTimeInWater decrease by 25%.
    //Also, spawnTime will decrease with score. (Game will speed up)
    //Need to set variable (25), and whenever the score is twice the variable modify sprite variables and set new variable(25*2..)
    public static float valueToModifyVars;
    public sprite_control foodVars;
    public object_pool_control spawnTimeVar;

    public bool paused = false;
    public UnityEngine.UI.Button pause_buttn;
    public UnityEngine.UI.Image pause_image;
    public Sprite play_img;
    public Sprite pause_img;

    public GameObject gameOverButtons;
    public object_pooler object_pool;

    void Start()
    {
        totalMissedFood = 0;
        valueToModifyVars = (float)12.5;
        if (SceneManager.GetActiveScene().name == "In_Game")
        {
            gameOverButtons.SetActive(false);
            pause_image.enabled = false;
        }
    }

    void Update() {
        if (totalMissedFood >= 3)
        {
            totalScore += score;
            gameOverButtons.SetActive(true);
            Time.timeScale = 0;
            for (int i = 0; i < object_pool.pooledObjects.Count; i++)
            {
                object_pool.pooledObjects[i].SetActive(false);
            }
        }
        if (score == valueToModifyVars * 2)
        {
            //1.25 is a "double" whereas fallSpeed is a "float". Doubles take up more memory than floats.
            //TODO: Create more well thought out checkpoints in the game as score increases.
            foodVars.fallSpeed *= (float)1.25;
            foodVars.sinkSpeed *= (float)1.25;
            foodVars.timeBeforeSink *= (float).75;
            foodVars.expirationTimeInWater *= (float).75;
            spawnTimeVar.spawnTime *= (float).4;
            valueToModifyVars = score;
        }
    }

    public void missedFood()
    {
        totalMissedFood++;
    }

    public void pause_button()
    {
        if (paused == false)
        {
            paused = true;
            pause_image.enabled = true;
            pause_buttn.image.overrideSprite = play_img;
            Time.timeScale = 0;
        }
        else if (paused == true)
        {
            paused = false;
            pause_image.enabled = false;
            pause_buttn.image.overrideSprite = pause_img;
            Time.timeScale = 1;
        }
    }

    public void timeScale1()
    {
        Time.timeScale = 1;
    }

    public void play_again_button()
    {
        score = 0;
        totalMissedFood = 0;
        gameOverButtons.SetActive(false);
        Time.timeScale = 1;
        for (int i = 0; i < object_pool.pooledObjects.Count; i++)
        {
            object_pool.pooledObjects[i].SetActive(true);
        }
        Debug.Log("No Error");
    }

    public void play_button()
    {
        score = 0;
        totalMissedFood = 0;
        timeScale1();
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
