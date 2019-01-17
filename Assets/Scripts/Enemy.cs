using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //Unity calls this function automatically when the enemy touches any other object.

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Checks if the object the enemy has collided with has a player script and is therefore the player.
        Player playerScript = collision.collider.GetComponent<Player>();

        //Kills the player if they collide with the enemy.
        if (playerScript != null)
        {
            playerScript.Kill();

        }
  
    }
}