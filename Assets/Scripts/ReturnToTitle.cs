using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ReturnToTitle : MonoBehaviour {

    //Used to make the game scene transition from the high score screen back to the title screen when the correct input button is pressed by the player.

    void Update()
    {
        if (Input.GetButtonDown("Submit")) { SceneManager.LoadScene("Title-Screen"); }
    }
}
