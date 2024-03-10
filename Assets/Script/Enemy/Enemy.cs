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
            Debug.Log("进来OnTrigger函数了");

            collision.GetComponent<Attribute>().TakeDamage(this);
        }
    }
}
