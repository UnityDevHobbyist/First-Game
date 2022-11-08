using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 10;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);
    }
}
