﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Extra using statement to allow us to use the scene management functions
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    //Variable to let us add to the score
    //Public so we can drag and drop
    public Score scoreObject;

    //Designer Variables
    public string sceneToLoad;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if the thing that we collided with is the player (Aka has a player script)
        Player playerScript = collision.collider.GetComponent<Player>();
        {
            //Only do something if the thing we ran into was in fact the player aka playerScript is not null
            if (playerScript != null)
            {
                //save the score using our score object reference
                scoreObject.SaveScore();

                //Load the next level
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}
  
