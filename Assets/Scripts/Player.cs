using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Config
    public int health = 3;
    [Header("Player Movement")]
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float jumpSpeed = 12f;
    private float jumpPressedDelay = 0f;
    private float jumpPressedDelayTime = 0.15f;
    [SerializeField] private float climbSpeed = 2f;
    //For damage knockback effect
    [Header("Player Knockback")]
    [SerializeField] private float damageDelay = 1f;
    [SerializeField] private float knockback = 5f;

    public float knockbackLength = 0.2f;
    public float knockbackCount = 0f;
    public bool knockbackFromRight;

    private Vector2 movement;

    //Bool states
    private bool isAlive = true;
    private bool isImmune = false;

    private Rigidbody2D rb2d;
    private Animator myAnimator;
    private PolygonCollider2D myColliderFeet;

    private float gravityAtStart;

    void Start()
    {
        //Cached component refernces
        rb2d = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myColliderFeet = GetComponent<PolygonCollider2D>();

        gravityAtStart = rb2d.gravityScale;

        //Dissolve at start of level
        FindObjectOfType<Dissolve>().DissolveIn();
    }

    void Update()
    {
        if (!isAlive)
        {
            return;
        }
        GetInput();
        WaterDeath();
    }

    void FixedUpdate()
    {
        //The player will be knocked back on collisions. 
        if (knockbackCount <= 0)
        {
            Walk();
            Jump();
            FlipSprite();
            Climb();
        }
        else
        {
            myAnimator.SetTrigger("Damage");
            if (knockbackFromRight)
                rb2d.velocity = new Vector2(-knockback, knockback);
            if (!knockbackFromRight)
                rb2d.velocity = new Vector2(knockback, knockback);
            knockbackCount -= Time.deltaTime;
        }
    }

    void Walk()
    {
        float controlThrow = movement.x;
        Vector2 playerVelocity = new Vector2(controlThrow * movementSpeed, rb2d.velocity.y);
        rb2d.velocity = playerVelocity;
    }

    void GetInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //movement.Normalize();

        jumpPressedDelay -= Time.deltaTime;
        if (Input.GetButtonDown("Jump"))
        {
            jumpPressedDelay = jumpPressedDelayTime;
        }
        //Reduce jump velocity after releasing button
        if (Input.GetButtonUp("Jump") && rb2d.velocity.y > 0)
        {
            rb2d.velocity = new Vector2(0f, rb2d.velocity.y * 0.65f);
        }
    }

    void FlipSprite()
    {
        //Check input for horizontal motion
        bool playerHasHorizontalSpeed = Mathf.Abs(rb2d.velocity.x) > Mathf.Epsilon;
        //Change Animation State
        myAnimator.SetBool("Walking", playerHasHorizontalSpeed);
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb2d.velocity.x), 1);
        }
    }

    void Jump()
    {
        //Play jump animation for jump, or for falling
        if (!myColliderFeet.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            myAnimator.SetBool("Jumping", true);
            return;
        }
        else
        {
            myAnimator.SetBool("Jumping", false);
        }

        //Jump delay to allow jumping just before landing
        if (jumpPressedDelay > 0)
        {
            jumpPressedDelay = 0;
            rb2d.velocity = new Vector2(0f, jumpSpeed);
            
        }

    }

    void Climb()
    {
        if (!myColliderFeet.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            myAnimator.SetBool("Climbing", false);
            rb2d.gravityScale = gravityAtStart;
            return;
        }

        rb2d.gravityScale = 0f;

        float controlThrow = movement.y;
        Vector2 climbVelocity = new Vector2(rb2d.velocity.x, controlThrow * climbSpeed);
        rb2d.velocity = climbVelocity;

        myAnimator.SetBool("Jumping", false);
        myAnimator.SetBool("Climbing", true);
    }

    //When Player Takes Damage
    public void TakeDamage()
    {
        if(!isAlive)
        { return; }
        if (health >= 1)
        {
            StartCoroutine(ProcessDamage());
        }
        else
        {
            FindObjectOfType<Dissolve>().DissolveOut();
            isAlive = false;
            FindObjectOfType<SFXPlayer>().DeathMeow();
            StartCoroutine(DeathAnimation());
        }
    }

    IEnumerator ProcessDamage()
    {
        if (!isImmune)
        {
            isImmune = true;
            health--;
            FindObjectOfType<SFXPlayer>().DamageMeow();
            FindObjectOfType<UIController>().UpdateHealth();  
        }
        yield return new WaitForSecondsRealtime(damageDelay);
        isImmune = false;
    }

    IEnumerator DeathAnimation()
    {

        yield return new WaitForSecondsRealtime(0.5f);

        FindObjectOfType<GameSession>().ProcessPlayerDeath();
    }

    void WaterDeath()
    {
        if (myColliderFeet.IsTouchingLayers(LayerMask.GetMask("Water")))
        {
            FindObjectOfType<Dissolve>().DissolveOut();
            isAlive = false;
            FindObjectOfType<SFXPlayer>().DeathMeow();
            StartCoroutine(DeathAnimation());
        }
    }

    //Collision with enemy
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (transform.position.x < collision.transform.position.x)
            knockbackFromRight = true;
        else
            knockbackFromRight = false;
    }

}
