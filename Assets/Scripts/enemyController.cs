using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    // for damage calculation
    public int health = 1;
    public GameObject deathEffect;
    [SerializeField] Canvas loseGUI;
    public AudioSource lose1;
    public AudioSource lose2;

    //for movement
    private float Xdirection;
    private float moveSpeed;
    private Rigidbody2D rigidBod;
    private bool facingRight = false;
    private Vector3 localScale;

    //since they only have 1 hp they just die
    
    void Start()
    {
        localScale = transform.localScale;
        rigidBod = GetComponent<Rigidbody2D>();
        Xdirection = -1f;
        moveSpeed = 3f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Xdirection *= -1f;
        }
        else if (collision.gameObject.tag == "Player")
        {
            playerController.playerHealth -= 1;
            if (playerController.playerHealth <= 0)
            {
                loseGUI.enabled = !loseGUI.enabled;
                lose1.Play();
                lose2.Play();
            }
        }
    }

    private void FixedUpdate()
    {
        rigidBod.velocity = new Vector2(Xdirection * moveSpeed, rigidBod.velocity.y);
    }

    void checkDirection()
    {
        if (Xdirection > 0)
        {
            facingRight = true;
        } else if (Xdirection < 0)
        {
            facingRight = false;
        }

        if ((localScale.x < 0 && facingRight) || (localScale.x > 0 && !facingRight))
        {
            facingRight = !facingRight;
        }
        transform.Rotate(0f, 180f, 0f);
    }


    private void LateUpdate()
    {
        checkDirection();
    }

    public void TakeDamage()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
