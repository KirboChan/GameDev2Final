using System;
using System.Collections;
using UnityEngine;

public class ThisPlayer: MonoBehaviour
{
    //welcome to the player script!


    //used to call the rigidbody, which is used for most of the physics of the player including gravity
    public Rigidbody2D rb;
    //uses a public variable to check whether the player is on the ground.
    public Transform groundCheck;
    //checks if the layer is currently on the ground or not.
    public LayerMask groundLayer;
    bool facingRight = true;
    //checks whether the player is on the ground or not, use a check later.
    public bool isGrounded;
    public int facingDirection = 1;
    //checks whether the player is doing a middair dash or not.
    public bool isDashing = false;
    //checks whether the player is stomping or not
    //checks if the player can move or not.
    bool canMove = true;
    //checks if the player can jump or not
    bool canJump;
    //check if the player can dash or not
    bool canDash = true;
    //check if the player can stomp or not
    Vector2 dashingDirection;
    //the value of how fast the player moves.
    float moveSpeed = 5.5f;
    //how fast the player jumps
    float jumpspeed = 5f;
    //the value of how fast the player slides off walls
    float dashingSpeed = 8f;
    //the value of how high the player will jump when dashing into a wall
    //the direction a player will wallJump
    float jumpTime;
    //how long the player dashes
    float dashTime = 0.15f;
    //the move imput of the player, will be assigned later
    float moveImput;
    //the dash imput of the player, will be assigned later
    float dashImput;
    //how long the player can jump while pressing the jump button
    float jumpButtonSpeed = 0.2f;

    void Start()
    {
        //the framerate of the game, running at 60 fps
        Application.targetFrameRate = 60;
        //the player trail is set to false, and the ability to stomp is set to 
    }

    void FixedUpdate()
    {
        //sets the movement imput
        moveImput = Input.GetAxis("Horizontal");
        //sets the dash imput
        dashImput = Input.GetAxisRaw("Dash");
        //sets itsGrounded to be based of the position of an object that checks where the ground is, using the ground layer as a base
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);
    }

    void Update()
    {
        //the code for the movement, first checks if the player is able to move
        if (canMove == true)
        {
            //if the player is on the ground on its own, then the player trail is set to false while canDash is set to true
            if (isGrounded)
            {
                canDash = true;
            }

            //if the moveimput isn't equal to 0, aka if the left or right imput is pressed
            if (moveImput != 0)
            {
                //the velocity of the player will multiply the moveImput by the movespeed, while checking the y velocity
                rb.velocity = new Vector2(moveImput * moveSpeed, rb.velocity.y);
                //if moveimput is less than 0 (-1), and the player is facing right, then the player will flip
                if (moveImput < 0 && facingRight)
                {
                    Flip();

                }
                //if the moveimput is more than 0(1) and the player is facing left, then the player will flip again
                else if (moveImput > 0 && !facingRight)
                {
                    Flip();

                }
            }


            //if the player presses the jump button and the player is on the ground, can jump is set to true and the jump time is equal to 0
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                canJump = true;
                jumpTime = 0;
            }

            //if the player is jumping and isn't wallsliding, then the y velocity will equal the jumpspeed, and jumpTime will equal add by the current gametime.
            if (canJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpspeed);
                jumpTime += Time.deltaTime;
            }


            //if the jump button is released and the jumptime is over how long the jumpbutton is pressed, then canJump equals false
            if (Input.GetButtonUp("Jump") || jumpTime > jumpButtonSpeed)
            {
                canJump = false;
            }

            //if the player is dashing, and able to dash, then it will say that the player is dashing and set the ability to false
            if (dashImput > 0 && canDash)
            {
                isDashing = true;
                canDash = false;
                //the direction of where the player is calculated using both the moveimput and the vertical direction, then would stop dashing
                dashingDirection = new Vector2(moveImput, Input.GetAxisRaw("Vertical"));
                if (dashingDirection == Vector2.zero)
                {
                    dashingDirection = new Vector2(transform.localScale.x, y: 0);
                }
                StartCoroutine(stopDashing());
            }
            //if isDashing is true, then the trail is turned on and the velocity is set to dashingDirection * dashingSpeed

            if (isDashing)
            { 
                rb.velocity = dashingDirection.normalized * dashingSpeed;
            }
        }
    }
    //the code will wait for a 0.15 seconds then set dashing and its trail to false
    IEnumerator stopDashing()
    {
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
    }
    //the player flips itself, and facingDirection and facingRight is set to its opposite
    void Flip()
    {
        facingDirection *= -1;
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    private void StartCourentine(IEnumerator enumerator)
    {
        throw new NotImplementedException();
    }
}
