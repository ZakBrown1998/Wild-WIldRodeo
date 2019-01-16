
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    // designer variables
    public float speed = 10;
    public float jumpSpeed = 10;
    public Rigidbody2D physicsBody;
    public string horizontalAxis = "Horizontal";
    public string jumpButton = "Jump";
    public Animator playerAnimator;
    public SpriteRenderer playerSprite;
    public Collider2D playerCollider;

    //variable to keep a reference to the lives display object
    public Lives livesObject;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // Get axis input from Unity
        float leftRight = Input.GetAxis(horizontalAxis);


        // Create direction vector from axis input
        Vector2 direction = new Vector2(leftRight, 0);

        // Make direction vector length 1
        direction = direction.normalized;

        // Calculate velocity
        Vector2 velocity = direction * speed;
        velocity.y = physicsBody.velocity.y;

        // Give the velocity to the rigidbody
        physicsBody.velocity = velocity;

        //Tell the animator our speed
        playerAnimator.SetFloat("walkSpeed", Mathf.Abs(velocity.x));

        //Flip our sprites if we're moving backward
        if (velocity.x < 0)
        {
            playerSprite.flipX = true;
        }
        else
        {
            playerSprite.flipX = false;
        }




        //Jumping

        //Detect if we are touching the ground
        //Get the LayerMask from Unity using the name of the layer
        LayerMask groundLayerMask = LayerMask.GetMask("Ground");

        //Ask the player's collider if we are touching the LayerMask
        bool touchingGround = playerCollider.IsTouchingLayers(groundLayerMask);

        playerAnimator.SetBool("TouchingGround", touchingGround);

        bool jumpButtonPressed = Input.GetButtonDown(jumpButton);
        if (jumpButtonPressed == true && touchingGround == true)
        {
            //We have pressed Jump so we should set our upward velocity to ouyr jumpSpeed
            velocity.y = jumpSpeed;

            //Give the velocity to the rigidbody
            physicsBody.velocity = velocity;
        }

        if (physicsBody.velocity.y < 0)
            playerAnimator.SetBool("Falling", true);
        else
            playerAnimator.SetBool("Falling", false);

    }
    
    


 public void Kill()
{
        //Take away a life and save that change
  livesObject.LoseLife();
  livesObject.SaveLives();

        //Check if it's game over

      bool gameOver = livesObject.isGameOver();

        //If it is game over, load the game over screen

//
   if (gameOver == true)
       {
           SceneManager.LoadScene("GameOver");
      }
        else
      {


            //If it is not game over, reset the current level to restart from the beginning


            //Reset the cuurent level to restart from the beginning
            //First, ask unity what the current level is


 Scene currentLevel = SceneManager.GetActiveScene();

 SceneManager.LoadScene(currentLevel.buildIndex);
}

 }

}



