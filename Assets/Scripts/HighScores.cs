using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Needed for working with Text components
using UnityEngine.UI;

public class HighScores : MonoBehaviour {

    //Used to display high scores
    public List<Text> highScoresDisplays = new List<Text>();

    //Internal data for score values 
    private List<int> highScoreData = new List<int>();

    // Use this for initialization
    void Start()
    {
        //Load the high score data from the PlayerPrefs
        LoadHighScoreData();

        //Get our current score from PlayerPrefs
        int currentScore = PlayerPrefs.GetInt("score", 0);

        //Check if we got a new high score
        bool haveNewHighScore = IsNewHighScore(currentScore);
        if (haveNewHighScore = true)
        {
            //Add new score to the data 
            AddScoreToList(currentScore);
            //Save updated data
            SaveHighScoreData();
        }
        //update the visual display
        UpdateVisualDisplay();
    }

    // Update is called once per frame
    void Update() {

    }

    private void LoadHighScoreData()
    {
        for (int i = 0; i < highScoresDisplays.Count; ++i)
        {
            //Using the loop index, get the name for our PlayerPrefs key
            string prefsKey = "highScore" + 1.ToString();

            //Use this key to get the high score value from PlayerPrefs
            int highScoreValue = PlayerPrefs.GetInt(prefsKey, 0);

            //Store this score value in our internal data list
            highScoreData.Add(highScoreValue);
        }
    }
    private void UpdateVisualDisplay()
    {
        for (int i = 0; i < highScoresDisplays.Count; ++i)
        {
            //Find the specific text and numbers in our list and set the text to the numerical score
            highScoresDisplays[i].text = highScoreData[i].ToString();
        }
    }

    private bool IsNewHighScore(int scoreToCheck)
    {
        //Loop through the high scores and see if the new score is higher than any of them
        for (int i = 0; i < highScoresDisplays.Count; ++i)
        {
            //Is the new score higher than the high score we're checking this loop?
            if (scoreToCheck > highScoreData[i])
            {
                //New score is higher!
                //Return to the calling code that the new score IS a new high score
                return true;
            }
        }
        //default false
        //We did not find any scores higher than the high scores
        return false;
    }
    private void AddScoreToList(int newScore)
    { 
         for (int i = 0; i<highScoresDisplays.Count; ++i )
    {//is our new score higher than the score we're checking in the list?
            if (newScore > highScoreData [i])
            {
                //Our score is higher
                //Since we're going from highest to lowest
                //the first time our score is higher, this is where it must go
                //insert the new score into the list here

                highScoreData.Insert(i, newScore);

                //trip the last item off the list
                highScoreData.RemoveAt(highScoreData.Count - 1);

                //we're done we must exit early
                return;
            }

    }

  }

    private void SaveHighScoreData()
    {
        for (int i = 0; i < highScoresDisplays.Count; ++i)
        {
            //Using the loop index, get the name for our PlayerPrefs key
            string prefsKey = "highScore" + i.ToString();

            //Get the current high score entry from the data
            int highScoreEntry = highScoreData[i];
            //Save this data to the PlayerPrefs
            PlayerPrefs.SetInt(prefsKey, highScoreEntry);
            
        }

        //Save the PlayerPrefs to disk
        PlayerPrefs.Save();
    }





}
