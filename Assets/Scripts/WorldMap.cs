using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WorldMap : MonoBehaviour
{
    [SerializeField] GameObject[] level;
    [SerializeField] float movementSpeed = 2f;

    [SerializeField] Transform movePoint;

    [SerializeField] LayerMask obstacle;
    private Vector2 startingPos = new Vector2(-11.5f, 1.75f);
    private Vector2 zeroPos = new Vector2(0f, 0f);


    // Start is called before the first frame update
    private void Start()
    {
        //Reset player position
        int levelNumber = FindObjectOfType<GameSession>().levelNumber;

        if (levelNumber > 0)
        {
            if (FindObjectOfType<GameSession>().lastLocation == new Vector2(0,0))
            {
                gameObject.transform.position = startingPos;
                movePoint.position = startingPos;
            }
            else
            {
                gameObject.transform.position = FindObjectOfType<GameSession>().lastLocation;
                movePoint.position = FindObjectOfType<GameSession>().lastLocation;
            }
            
        }
        //Unparent the movepoint
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
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
    }

}

