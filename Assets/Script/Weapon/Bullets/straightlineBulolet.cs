using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class straightlineBulolet : Bullet
{
    public float offset;
    public override void GetDirection(GameObject player)
    {
        base.GetDirection(player);
        if(offset != 0 )
        {
            direction += new Vector2(0,Random.Range(0f,offset));
        }
        
    }
    protected override void BulletFly()
    {
        rigidbody2d.velocity = direction*flySpeed;
    }
}
