using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * speed;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemyController monster = collision.GetComponent<enemyController>();
        if (monster != null) { monster.TakeDamage(); }
        Destroy(gameObject);
    }
}
