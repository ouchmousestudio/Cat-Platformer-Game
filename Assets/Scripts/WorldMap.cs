using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WorldMap : MonoBehaviour
{
    [SerializeField] GameObject[] level;
    [SerializeField] float movementSpeed = 3f;

    Rigidbody2D myRigidbody;

    [SerializeField] Transform movePoint;

    [SerializeField] LayerMask obstacle;


    // Start is called before the first frame update
    private void Start()
    {
        

        //Reset player position
        int levelNumber = FindObjectOfType<GameSession>().levelNumber;


        if (levelNumber > 0)
        {
            gameObject.transform.position = FindObjectOfType<GameSession>().lastLocation;
            movePoint.position = FindObjectOfType<GameSession>().lastLocation;
        }

        //Unparent the movepoint
        movePoint.parent = null;

        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }

    void Movement()
    {
        //Smooth movement type
        //float xMove = Input.GetAxis("Horizontal");
        //float yMove = Input.GetAxis("Vertical");
        //Vector2 playerVelocity = new Vector2(xMove * movementSpeed, yMove * movementSpeed);
        //myRigidbody.velocity = playerVelocity;



        //Input by steps
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, movementSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), 0.2f, obstacle))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), 0.2f, obstacle))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            FindObjectOfType<GameSession>().lastLocation = gameObject.transform.position;

        }



    }


}

