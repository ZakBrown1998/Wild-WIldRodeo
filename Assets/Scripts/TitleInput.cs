using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class TitleInput : MonoBehaviour
{

    
    
    void Update()
    {
        //Used to make the game scene transition from the current one to a new one.
        //The transisition depends on the correct input button being pressed by the player.
        if (Input.GetButtonDown("Submit")) { SceneManager.LoadScene("Controls"); }
    }
}
