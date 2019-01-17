using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Allows access to the scene loading fucntion.
using UnityEngine.SceneManagement;

public class StartGameInput : MonoBehaviour {

    //
    void Update()
    {
        //Loads the next scene and starts the game if the player has pressed the correct input button.
        if (Input.GetButtonDown("Submit")) { SceneManager.LoadScene("Level-1"); }
        
    }
	
}
