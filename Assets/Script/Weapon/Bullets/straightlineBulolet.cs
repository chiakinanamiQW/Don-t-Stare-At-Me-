using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class straightlineBulolet : Bullet
{
    
    protected override void BulletFly()
    {
        rigidbody2d.velocity = direction*flySpeed;
    }
}
