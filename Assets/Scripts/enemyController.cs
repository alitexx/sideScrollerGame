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
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("i have touched a wall");
            Xdirection *= -1f;
        }
        if (collision.gameObject.tag == "Player")
        {
            Xdirection *= -1f;
            playerController.playerHealth -= 1;
            if (playerController.playerHealth <= 0)
            {
                loseGUI.gameObject.SetActive(!loseGUI.gameObject.activeInHierarchy);
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
        if ((Xdirection < 0 && facingRight) || (Xdirection > 0 && !facingRight))
        {
            facingRight = !facingRight;

            transform.Rotate(0f, 180f, 0f);
        }
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
