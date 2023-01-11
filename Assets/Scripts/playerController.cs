using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody2D rigidBod;
    public float speed;
    private bool turnedRight = false;
    private float push;
    // Start is called before the first frame update
    void Start()
    {
        rigidBod= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        push = Input.GetAxis("Horizontal");

        // if the sprite is not turned right but is moving back
        // or if the sprite is moving forward and is actively facing the right
        // TODO fix this it is not working
        if ((push < 0 && turnedRight == false) || (push > 0 && turnedRight == true))
        {
            turnedRight = !turnedRight;
            transform.Rotate(0f, 180f, 0f);
        }



        rigidBod.velocity = new Vector2(push * speed,0);
    }
}
