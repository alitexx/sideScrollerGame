using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class playerController : MonoBehaviour
{
    private Animator m_Animator;
    private Rigidbody2D m_Rigidbody;
    private bool facingRight = true;

    public float playerSpeed = 2.0f;
    public float horiMovement;
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        horiMovement = Input.GetAxisRaw("Horizontal");

    }

    private void FixedUpdate()
    {
        m_Rigidbody.velocity = new Vector2 (horiMovement*playerSpeed, m_Rigidbody.velocity.y);
        flipChar(horiMovement);
    }
    private void flipChar(float horizontal)
    {
        if ((horizontal < 0 && facingRight) || (horizontal > 0 && !facingRight))
        {
            facingRight = !facingRight;

            Vector3 scaleVal = transform.localScale;
            scaleVal.x *= -1;
            transform.localScale = scaleVal;
        }
    }
}
