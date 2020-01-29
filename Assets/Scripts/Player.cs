using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Config
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpSpeed = 6f;
    [SerializeField] float climbSpeed = 2f;


    //State
    bool isAlive = true;

    //Cached component refernces
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    Collider2D myCollider2D;

    float gravityAtStart;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider2D = GetComponent<Collider2D>();

        gravityAtStart = myRigidbody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Jump();
        Climb();
        FlipSprite();
    }


    void Walk()
    {
        float controlThrow = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(controlThrow * movementSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        //myRigidbody.velocity = playerVelocity * Time.deltaTime;
        
    }

    void Jump()
    {
        if(!myCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            myAnimator.SetBool("Jumping", false);
            return;
        }
        else
        {
            if (Input.GetButtonDown("Jump"))
            {
                //Change Animation State

                Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
                myRigidbody.velocity += jumpVelocity;
                myAnimator.SetBool("Jumping", true);
            }
        }

        

    }

    void Climb()
    {
        if (!myCollider2D.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            myAnimator.SetBool("Climbing", false);
            myRigidbody.gravityScale = gravityAtStart;
            return;
        }
        else
        {
            myAnimator.SetBool("Climbing", true);
        }

        myRigidbody.gravityScale = 0f;

        float controlThrow = Input.GetAxis("Vertical");
        Vector2 climbVelocity = new Vector2(myRigidbody.velocity.x, controlThrow * climbSpeed);
        myRigidbody.velocity = climbVelocity;

        //bool playerHasVerticalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        //myAnimator.SetBool("Climbing", playerHasVerticalSpeed);

    }

    void FlipSprite()
    {
        //Check input for horizontal motion
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        //Change Animation State
        myAnimator.SetBool("Walking", playerHasHorizontalSpeed);
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1);
        }
    }
}
