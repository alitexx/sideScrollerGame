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
    public GameObject healthGUI;

    public Animator playerAnimator;

    //for movement
    private float Xdirection;
    private float moveSpeed;
    private Rigidbody2D rigidBod;
    private bool facingRight = false;
    private Vector3 localScale;
    private bool debounce;

    //since they only have 1 hp they just die

    void Start()
    {
        localScale = transform.localScale;
        rigidBod = GetComponent<Rigidbody2D>();
        Xdirection = -1f;
        moveSpeed = 3f;
        debounce = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            updateRotation();
            Debug.Log("HEY YOU!!! MOVE!!!!!!!!!!");
            healthGUI.transform.GetChild(playerController.playerHealth).gameObject.SetActive(false);
            playerController.playerHealth -= 1;
            StartCoroutine(Debounced());
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


    private IEnumerator Debounced()
    {
        // fire event for player so they have a take damage anim
        if (playerController.playerHealth <= 0)
        {
            loseGUI.gameObject.SetActive(!loseGUI.gameObject.activeInHierarchy);
            rigidBod.gameObject.SetActive(false);
            lose1.Play();
            lose2.Play();
        }
        yield return new WaitForSeconds(1f);
        debounce = false;
    }

    public void updateRotation()
    {
        Xdirection *= -1f;
    }
}
