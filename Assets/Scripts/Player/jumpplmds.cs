using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpplmds : MonoBehaviour
{
    public bool Grounded;
    [Range(0, 10)]
    public float jumpForce;
    public Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (Grounded)
                Jump();
        }


        Grounded = true;
    }

    void Jump()
    {
        Debug.Log(Vector2.up);
        rb.velocity = Vector2.up * jumpForce;
    }
}
