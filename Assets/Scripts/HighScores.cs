using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Used for working with text components.
using UnityEngine.UI;

public class HighScores : MonoBehaviour {

    //Used to display high scores.
    public List<Text> highScoreDisplays = new List<Text>();

    //Internal data for score values.
    private List<int> highScoreData = new List<int>();

    // Used for initialization.
    void Start()
    {
        //Loads the high score data from the PlayerPrefs.
        LoadHighScoreData();

        //Gets the current score from PlayerPrefs.
        int currentScore = PlayerPrefs.GetInt("score", 0);

        //Checks if the current score is a new high score.
        bool haveNewHighScore = IsNewHighScore(currentScore);

        if (haveNewHighScore == true)
        {
            //Adds new score to the data. 
            AddScoreToList(currentScore);
            //Saves updated data.
            SaveHighScoreData();
        }
        //Updates the visual display.
        UpdateVisualDisplay();
    }

    // Update is called once per frame.
    void Update() {

    }
    //Function used to load the high score data.
    private void LoadHighScoreData()
    {
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            //Uses the loop index and gets the name for the PlayerPrefs key.
            string prefsKey = "highScore" + i.ToString();

            //Use this key to get the high score value from PlayerPrefs.
            int highScoreValue = PlayerPrefs.GetInt(prefsKey, 0);

            //Store this score value in the internal data list.
            highScoreData.Add(highScoreValue);
        }
    }

    //Function used to update the visual display.
    private void UpdateVisualDisplay()
    {
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            //Finds the specific text and numbers in the list and sets the text to the numerical score.
            highScoreDisplays[i].text = highScoreData[i].ToString();
        }
    }

    private bool IsNewHighScore(int scoreToCheck)
    {
        //Loops through the high scores and checks if the new score is higher than any of them.
        for (int i = 0; i < highScoreDisplays.Count; ++i)

        {
            //Confirms if the new score is higher than any of the high scores on the loop.
            if (scoreToCheck > highScoreData[i])
            {
                //Confirms the new score is higher.
                //Returns to the calling code that the new score is a new high score.
                return true;
            }
        }
        //Confirms the new score is not higher than any of the high scores.
        return false;
    }

    //Adds the player's new high score to the list.
    private void AddScoreToList(int newScore)
    { 
         for (int i = 0; i<highScoreDisplays.Count; ++i )

            {//Checks if the new score is higher than the high score data.
            if (newScore > highScoreData [i])
            {
                //The new score is higher
                //inserts the new score into the list.
                highScoreData.Insert(i, newScore);

                //trips the last item off the list
                highScoreData.RemoveAt(highScoreData.Count - 1);

                //Exits the function early
                return;
            }

    }

  }

    //Saves the high score data.
    private void SaveHighScoreData()
    {
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            //Gets the name for the PlayerPrefs key using the loop index.
            string prefsKey = "highScore" + i.ToString();

            //Gets the current high score entry from the data.
            int highScoreEntry = highScoreData[i];
            //Saves the data to the PlayerPrefs.
            PlayerPrefs.SetInt(prefsKey, highScoreEntry);
            
        }

        //Saves the PlayerPrefs to disk.
        PlayerPrefs.Save();
    }

}
