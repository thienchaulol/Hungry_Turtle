using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ingame_score : MonoBehaviour {

    public game_manager game_manager;
    public UnityEngine.UI.Text score_display;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        score_display.text = game_manager.score.ToString();
	}
}
