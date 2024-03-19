using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour//ÒÆ¶¯
{
    private Attribute attribute;
    private Rigidbody2D rb;
    public float Speed;
    private void Awake()
    {
        attribute = GetComponent<Attribute>();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        float Move_x = Input.GetAxis("Horizontal");
        float Move_y = Input.GetAxis("Vertical");
        Vector2 Direction=new Vector2(Move_x, Move_y).normalized;
        rb.velocity = Direction * attribute.Speed ;
    }
}
