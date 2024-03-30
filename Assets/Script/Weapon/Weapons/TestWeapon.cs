using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeapon : Weapon
{
    public override void Attack()
    {
        base.Attack();
        animator.SetTrigger("Attack");
    }
}
