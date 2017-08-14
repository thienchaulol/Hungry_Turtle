using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rewards_points : MonoBehaviour {

    public UnityEngine.UI.Text points_display;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        points_display.text = ("Points: " + game_manager.totalScore.ToString());
    }
}
