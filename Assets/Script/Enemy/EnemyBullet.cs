using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet :Enemy
{
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Attribute>().TakeDamage(this);
            Destroy(this);
        }
    }
 
 


}
