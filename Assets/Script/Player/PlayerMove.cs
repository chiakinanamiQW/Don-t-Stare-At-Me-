using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove Instance;
    public PlayerData PlayerData;
    private Rigidbody2D rb;
    public float Speed;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Speed = PlayerData.InitialSpeed;
    }
    private void FixedUpdate()
    {
        float Move_x = Input.GetAxis("Horizontal");
        float Move_y = Input.GetAxis("Vertical");
        Vector2 Direction=new Vector2(Move_x, Move_y);
        rb.velocity = Direction * Speed ;
    }
}
