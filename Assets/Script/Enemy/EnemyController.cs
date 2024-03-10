using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header(" Ù–‘")]
    [SerializeField] private EnemyData enemyData;

    public Vector2 Movement {  get; private set; }
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    private void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
        sr= GetComponent<SpriteRenderer>();
        anim= GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
          
    }
     void  Move()
    {
        if (Movement.magnitude > 0.1f && enemyData.Speed >= 0){
        rb.velocity=Movement*enemyData.Speed;
            if (Movement.x < 0)
            {
                sr.flipX = false;
            }
            if(Movement.x > 0) 
            {
            sr.flipX=true;
            }
        }
        else
        {
            rb.velocity= Vector2.zero;  
        }
    }
}
