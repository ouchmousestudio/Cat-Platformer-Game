using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float movementSpeed = 1f;
    [SerializeField] float dyingTime = 0.5f;
    [SerializeField] GameObject player;


    Rigidbody2D myRigidbody;
    CapsuleCollider2D myCollider;

    bool enemyIsAttacking = false;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<CapsuleCollider2D>();

    }

    void Update()
    {

        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
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

    private bool isFacingUp()
    {
        return transform.localScale.y > 0;
    }
}
