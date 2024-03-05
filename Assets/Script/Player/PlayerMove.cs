using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{   public PlayerData PlayerData;
    private Rigidbody2D rb;
    public float Speed=5;
    private int Health;
    private void Start()
    {
        Health = PlayerData.MaxHealth;
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        float Move_x = Input.GetAxis("Horizontal");
        float Move_y = Input.GetAxis("Vertical");
        Vector2 Direction=new Vector2(Move_x, Move_y);
        rb.velocity = Direction * Speed ;
    }
}
