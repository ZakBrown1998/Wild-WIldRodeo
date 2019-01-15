using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This allows us to use the scene loading function
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

   //This will be called by the Button component
   //When the button is clicked
    public void StartGame()
    {
        //Reset the Score
        PlayerPrefs.DeleteKey("score");

        //Reset the Score
        PlayerPrefs.DeleteKey("lives");

        SceneManager.LoadScene("Level 1");
    }
	
}
