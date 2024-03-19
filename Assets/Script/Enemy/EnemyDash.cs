using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDash : MonoBehaviour
{
    private Rigidbody2D rb;

    public Rigidbody2D player;

    [Header("³å´Ì²ÎÊý")]
    public float dashDistance;
 
    public float dashTimer;
    public float dashDelay;
    private void Start()
    {
     rb=GetComponent<Rigidbody2D>();   
    }

    private void Update()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);
        Vector2 force = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);

        if (distance <= dashDistance)
        {
            dashTimer += Time.deltaTime;
            if (dashTimer > dashDelay)
            {
                rb.AddForce(force, ForceMode2D.Impulse);
                dashTimer = 0;
            }
        }
    }
}
