using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 1f;

    Rigidbody2D myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {

        if(isFacingLeft())
        {
            myRigidbody.velocity = new Vector2(-movementSpeed, 0f);
        }
        else
        {
            myRigidbody.velocity = new Vector2(movementSpeed, 0f);
        }

    }

    private bool isFacingLeft()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x),1f);
    }
}
