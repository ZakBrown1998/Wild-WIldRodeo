using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Lives : MonoBehaviour {

    public Text livesText;
    private int numericalLives = 3;

	// Used for initialization.
	void Start () {
        //Used to set the player's total lives to 3.
        numericalLives = PlayerPrefs.GetInt("lives", 3);
        livesText.text = numericalLives.ToString();
	}
	
	// Update is called once per frame.
	void Update () {
		
	}
    //A Function used to take away one of the player's lives when they die.
    public void LoseLife()
    {
        //Takes one life away from the player.
        numericalLives = numericalLives - 1;
        livesText.text = numericalLives.ToString();
    }
    //Used to write the updated lives count to memory.
    public void SaveLives()
    {
        //Used to set the lives count to the new value.
        PlayerPrefs.SetInt("lives", numericalLives);
    }
    //Used to determine if the player is in the game over state or not base don their remianing lives.
    public bool isGameOver()
    {
        if (numericalLives <= 0)
        {
            return true;            
        }
        else
        {
            return false;
        }
    }
    //Used to reset the player's lives after a game over has happened and the player has started a new game.
    [ContextMenu("ResetLives")]
        public void ResetLives()
    {
        PlayerPrefs.DeleteKey("lives");
    }

}
