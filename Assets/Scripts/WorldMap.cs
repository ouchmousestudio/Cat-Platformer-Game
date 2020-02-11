using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WorldMap : MonoBehaviour
{
    [SerializeField] GameObject[] level;
    [SerializeField] float movementSpeed = 3f;

    Rigidbody2D myRigidbody;


    // Start is called before the first frame update
    private void Start()
    {
        //Reset player position
        int levelNumber = FindObjectOfType<GameSession>().levelNumber;
        //if (levelNumber >= 1)
        //{
        //    levelNumber -= 1;
        //}

        //Vector2 offsetPos = new Vector2(level[levelNumber].transform.position.x, level[levelNumber].transform.position.y + 0.25f);
        //gameObject.transform.position = offsetPos;

        if (levelNumber > 0)
        {
            gameObject.transform.position = FindObjectOfType<GameSession>().lastLocation;
        }

        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        //if (Input.GetKeyDown("up"))
        //{
        //    gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f);
        //}
        //else if (Input.GetKeyDown("down"))
        //{
        //    gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f);
        //}
        //else if (Input.GetKeyDown("left"))
        //{
        //    gameObject.transform.position = new Vector2(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y);
        //}
        //else if (Input.GetKeyDown("right"))
        //{
        //    gameObject.transform.position = new Vector2(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y);
        //}
        float xMove = Input.GetAxis("Horizontal");
        float yMove = Input.GetAxis("Vertical");
        Vector2 playerVelocity = new Vector2(xMove * movementSpeed, yMove * movementSpeed);
        myRigidbody.velocity = playerVelocity;

        if (Input.GetButtonDown("Jump"))
        {
            FindObjectOfType<GameSession>().lastLocation = gameObject.transform.position;

        }
    }

}

