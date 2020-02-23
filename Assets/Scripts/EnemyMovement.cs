using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 1f;
    [SerializeField] GameObject splatterParticles;
    [SerializeField] float dyingTime = 0.5f;
    [SerializeField] GameObject player;

    Rigidbody2D myRigidbody;
    CapsuleCollider2D myColliderMid;
    CircleCollider2D myColliderTop;
    Animator myAnimator;

    bool enemyIsAlive = true;
    bool enemyIsAttacking = false;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        myAnimator = GetComponent<Animator>();
        myColliderTop = GetComponent<CircleCollider2D>();
        myColliderMid = GetComponent<CapsuleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (isFacingLeft())
        {
            myRigidbody.velocity = new Vector2(-movementSpeed, 0f);
                    }   
        else
        {
            myRigidbody.velocity = new Vector2(movementSpeed, 0f);
        }
            

        if (myColliderTop.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            if (!enemyIsAlive || enemyIsAttacking)
                return;
            else
            {
                Destroy(gameObject, dyingTime);
                movementSpeed = 0;
                myAnimator.SetBool("IsDead", true);
                FindObjectOfType<SFXPlayer>().DeathSqueak();
                //Instantiate(splatterParticles, transform.position, Quaternion.identity);
                enemyIsAlive = false;
            }
            
        }
        else if (myColliderMid.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            if (!enemyIsAlive)
                return;
            enemyIsAttacking = true;
            FindObjectOfType<Player>().TakeDamage();
            FindObjectOfType<Player>().knockbackCount = FindObjectOfType<Player>().knockbackLength;
            StartCoroutine(DamagePlayer());
        }

    }

    IEnumerator DamagePlayer()
    {
        yield return new WaitForSeconds(0.3f);
        enemyIsAttacking = false;
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
