using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  Atk : MonoBehaviour//¹¥»÷
{
    public int damage;
    public float PhyDamage;
    public float MaDamage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Attribute>().TakeDamage(this);
        }
    }
}
