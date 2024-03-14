using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("ËÙ¶È")]
    [SerializeField] private float currentSpeed;
    public Vector2 Movement { get;set; }

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        if (Movement.magnitude > 0.1f && currentSpeed >= 0)
        {
            rb.velocity = Movement * currentSpeed;
            if (Movement.x < 0)
            {
                sr.flipX = false;
            }
            if (Movement.x > 0)
            {
                sr.flipX = true;
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
