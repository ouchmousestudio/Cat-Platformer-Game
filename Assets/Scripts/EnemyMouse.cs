using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMouse : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private GameObject splatterParticles;
    [SerializeField] private float dyingTime = 0.3f;
    [SerializeField] private GameObject player;

    private Rigidbody2D myRigidbody;
    private CapsuleCollider2D myColliderMid;
    private CircleCollider2D myColliderTop;
    private Animator myAnimator;

    private bool enemyIsAlive = true;
    private bool enemyIsAttacking = false;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        myAnimator = GetComponent<Animator>();
        myColliderTop = GetComponent<CircleCollider2D>();
        myColliderMid = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {

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
                //Could add a death animation or particle effect here.

                enemyIsAlive = false;
            }
        }

        //Knockback player when he takes damage
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

    private void FixedUpdate()
    {
        if (isFacingLeft())
        {
            myRigidbody.velocity = new Vector2(-movementSpeed, 0f);
        }
        else
        {
            myRigidbody.velocity = new Vector2(movementSpeed, 0f);
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
        transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
    }
}
