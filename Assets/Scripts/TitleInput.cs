using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class TitleInput : MonoBehaviour
{

    //Used to make the game scene transition from the current one to a new one when the correct input button is pressed by the player.
    
    void Update()
    {
        if (Input.GetButtonDown("Submit")) { SceneManager.LoadScene("Controls"); }
    }
}
