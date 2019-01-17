using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoe : MonoBehaviour {

    //Variable to let us add to the score
    //Public so we can drag and drop
    public Score scoreObject;

    // Variable to hold the horseshoe's value
    //It's public so we can change it in the editor

    public int ShoeValue;

	// Used for initialization.
	void Start () {
		
	}
	
	// Update is called once per frame.
	void Update () {
		
	}

    //Unity calls this function when the horseshoe touches any other object.
    //If the player touched it, the horseshoe should vanish and score will go up.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Checks if the object collided with was the player.
        Player playerScript = collision.collider.GetComponent<Player>();

        //If the object collided with has a player script then score is added and the horseshoe is destroyed.
        if (playerScript)
        { 

            //Add to the score based on the horseshoe's value.
            scoreObject.AddScore(ShoeValue);

            //Destroy the gameObject that this script is attached to (i.e.The Horseshoe)
            Destroy(gameObject);
        }
    }
}
