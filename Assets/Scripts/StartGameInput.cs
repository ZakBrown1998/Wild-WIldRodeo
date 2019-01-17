using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Allows access to the scene loading fucntion.
using UnityEngine.SceneManagement;

public class StartGameInput : MonoBehaviour {

    //Update is called once per frame
    void Update()
    {
        // Reset the score
        PlayerPrefs.DeleteKey("score");

        // Reset the lives
        PlayerPrefs.DeleteKey("lives");
        //Loads the next scene and starts the game if the player has pressed the correct input button.
        if (Input.GetButtonDown("Submit")) { SceneManager.LoadScene("Level-1"); }
        //Reset the Score

    }
	
}
