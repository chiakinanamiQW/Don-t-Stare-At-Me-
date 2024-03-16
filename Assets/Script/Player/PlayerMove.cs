using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Attribute//ÒÆ¶¯
{ 
    private Rigidbody2D rb;
    public float Speed=5;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        float Move_x = Input.GetAxis("Horizontal");
        float Move_y = Input.GetAxis("Vertical");
        Vector2 Direction=new Vector2(Move_x, Move_y).normalized;
        rb.velocity = Direction * Speed ;
    }
}
