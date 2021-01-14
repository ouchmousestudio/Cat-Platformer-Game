using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject player;

    CapsuleCollider2D myCollider;

    bool enemyIsAttacking = false;

    void Start()
    {
        myCollider = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            if (enemyIsAttacking)
                return;
            else
            {
                enemyIsAttacking = true;
                FindObjectOfType<Player>().TakeDamage();
                FindObjectOfType<Player>().knockbackCount = FindObjectOfType<Player>().knockbackLength;
                StartCoroutine(DamagePlayer());
            }
        }
    }

    IEnumerator DamagePlayer()
    {
        yield return new WaitForSeconds(0.3f);
        enemyIsAttacking = false;
    }

}
