﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoe : MonoBehaviour {

    //Variable to let us add to the score
    //Public so we can drag and drop
    public Score scoreObject;

    // Variable to hold the horseshoe's value
    //It's public so we can change it in the editor

    public int ShoeValue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame 
	void Update () {
		
	}

    //Unity calls this function when the horseshoe touches any other object
    //If the player touched it, the coin should vanish and score will go up
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if the thing we touched was the player
        Player playerScript = collision.collider.GetComponent<Player>();

        //If the thing we touched has a player script, that means it is a player, so...
        if (playerScript)
        {
            //We hit the player!

            //Add to the score based on our value
            scoreObject.AddScore(ShoeValue);

            //Destroy the gameObject that this script is attached to (The Horseshoe)
            Destroy(gameObject);
        }
    }
}
