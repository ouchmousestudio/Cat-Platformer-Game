using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WorldMap : MonoBehaviour
{

    [SerializeField] BoxCollider2D levelOne;
    [SerializeField] BoxCollider2D levelTwo;

    BoxCollider2D myBoxCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetKeyDown("up"))
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.5f);
        }
        else if (Input.GetKeyDown("down"))
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f);
        }
        else if (Input.GetKeyDown("left"))
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x - 0.5f, gameObject.transform.position.y);
        }
        else if (Input.GetKeyDown("right"))
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + 0.5f, gameObject.transform.position.y);
        }
    }




}

