using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    //Unity calls this function automatically when the spikes touch any other object

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if the thing tht we collided with is the player (Aka has a player script)
        Player playerScript = collision.collider.GetComponent<Player>();

        //Only do something if the thing we ran into was in fact the player aka playerScript is not null
        if (playerScript != null)
        {
            // playerScript.Kill();

        }
    }
}