using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    //Unity calls this function automatically when the spikes touch any other object

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if the thing the spikes collided with is the player (i.e. has a player script)
        Player playerScript = collision.collider.GetComponent<Player>();

        //Kills the player if they collide with the spikes.
        if (playerScript != null)
        {
            //Kills the player.
             playerScript.Kill();

        }
    }
}