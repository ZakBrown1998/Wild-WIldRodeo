using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

  

    //Used to make the game scene transition from the game over screen to the high score screen when the correct input button is pressed by the player.

    void Update()
    {
        
        if (Input.GetButtonDown("Submit")) { SceneManager.LoadScene("High-Scores"); }
    }
}
