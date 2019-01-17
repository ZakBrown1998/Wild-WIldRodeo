
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    // Designer variables
    public float speed = 10;
    public float jumpSpeed = 10;
    public Rigidbody2D physicsBody;
    public string horizontalAxis = "Horizontal";
    public string jumpButton = "Jump";
    public Animator playerAnimator;
    public SpriteRenderer playerSprite;
    public Collider2D playerCollider;

    //A variable used to keep a reference to the lives display object.
    public Lives livesObject;


    // Used for initialization/
    void Start()
    {

    }

    // Update is called once per frame.
    void Update()
    {

        // Gets axis input from Unity.
        float leftRight = Input.GetAxis(horizontalAxis);


        // Creates direction vector from axis input.
        Vector2 direction = new Vector2(leftRight, 0);

        // Makes direction vector length 1.
        direction = direction.normalized;

        // Calculates velocity
        Vector2 velocity = direction * speed;
        velocity.y = physicsBody.velocity.y;

        // Gives the velocity to the rigidbody.
        physicsBody.velocity = velocity;

        //Gives the animatior the walking speed.
        playerAnimator.SetFloat("walkSpeed", Mathf.Abs(velocity.x));

        //Flips the sprite if it is moving backward.
        if (velocity.x < 0)
        {
            playerSprite.flipX = true;
        }
        else
        {
            playerSprite.flipX = false;
        }




        //Jumping

        //Detects if the player is touching the ground.
        //Gets the LayerMask from Unity using the name of the layer.
        LayerMask groundLayerMask = LayerMask.GetMask("Ground");

        //Checks the player's collider to see if they are touching the LayerMask.
        bool touchingGround = playerCollider.IsTouchingLayers(groundLayerMask);

        playerAnimator.SetBool("TouchingGround", touchingGround);
        //Checks to see if the jump button has been pressed.
        bool jumpButtonPressed = Input.GetButtonDown(jumpButton);
        if (jumpButtonPressed == true && touchingGround == true)
        {
            //Sets the upward velocity to the player's jump speed when they have pressed jump.
            velocity.y = jumpSpeed;

            //Give the velocity to the rigidbody.
            physicsBody.velocity = velocity;
        }
        //Sets the player to a falling state when their velocity is lower than 0.
        if (physicsBody.velocity.y < 0)
            playerAnimator.SetBool("Falling", true);
        else
            playerAnimator.SetBool("Falling", false);

    }
    
    

//Used to kill the player and program the after effects.
 public void Kill()
{
  //Takes away a life..
  livesObject.LoseLife();
  //Saves the change when the life is taken away.
  livesObject.SaveLives();

        //Checks if it's game over.

      bool gameOver = livesObject.isGameOver();


        //If it is game over the game over screen is loaded.

//Checks if the game is in game over state
   if (gameOver == true)
       {
            //Resets the player's lives
            livesObject.ResetLives();
            //Loads the game over scene.
           SceneManager.LoadScene("GameOver");

      }
        else
      {

//If it is not game over, the current level is reset
 Scene currentLevel = SceneManager.GetActiveScene();
//Checks Unity to find the current level
 SceneManager.LoadScene(currentLevel.buildIndex);
}

 }
    
}



