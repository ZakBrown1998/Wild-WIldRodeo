using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Allow use of the scene management functions.
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{

    //Allows access to the player's score.
    public Score scoreObject;

    //Allows the next scene to be loaded after the player collides with the flag.
    public string sceneToLoad;

    //Runs a function when the player collides with the flag.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Checks if the thing the flag collided with is the player. (Aka has a player script)
        Player playerScript = collision.collider.GetComponent<Player>();
        {
            //Function to save the player's score and load the next level.
            if (playerScript != null)
            {
                //saves the score using the score object reference.
                scoreObject.SaveScore();

                //Loads the next level.
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}
  
