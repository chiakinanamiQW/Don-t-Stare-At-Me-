using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeapon : Weapon
{
    public override void Attack()
    {
        Debug.Log(playerAttribute.MaxHealth);
        base.Attack();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TakeDamager");
    }
}
