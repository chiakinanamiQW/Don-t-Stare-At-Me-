using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   public EnemyData EnemyData;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("����OnTrigger������");

            collision.GetComponent<Attribute>().TakeDamage(this);
        }
    }
}
