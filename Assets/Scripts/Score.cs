using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Statement for using the Unity UI code.
using UnityEngine.UI;
public class Score : MonoBehaviour
{

    //Variable used to track the visible text score.
    //Public to let it be dragged and dropped in the editor.
    public Text scoreText;

    //Variable used to track the numerical score.
    //Private to prevent other scripts from changing it directly.
    //Defaults the score to 0 when the game is started.

    private int numericalScore = 0;

    // Used for initialization.
    void Start()
    {
        //Gets the score from the prefs database.
        //Uses a default of 0 if no score was saved.
        //Stores the result in the numerical score variable.
        numericalScore = PlayerPrefs.GetInt("score", 0);

        //Updates the visual score.
        scoreText.text = numericalScore.ToString();
    }

    // Update is called once per frame,
    void Update()
    {

    }

    //Function uesd to increase the score.
    //Public so other scripts can use it.
    public void AddScore(int _toAdd)
    {
        //Adds the amount to the numerical score.
        numericalScore = numericalScore + _toAdd;

        //Updates the visual score.
        scoreText.text = numericalScore.ToString();
    }
    // Function used to save the score to the player preferences.
    //Public so it can be triggered from another script.
    public void SaveScore()
    {
        PlayerPrefs.SetInt("score", numericalScore);

    }
}