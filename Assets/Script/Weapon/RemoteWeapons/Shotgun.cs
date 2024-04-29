using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Shotgun : RemoteWeapon
{
    public Vector2 offset;

    public int bulletNum;
    public override void Attack()
    {
        base.Attack();
        for (int i = 0; i < bulletNum; i++) 
        {
            Instantiate(WeaponBullet, transform.position + (Vector3)offset*i, transform.rotation);
        }
    }
}
