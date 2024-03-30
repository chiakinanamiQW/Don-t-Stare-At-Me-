using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBullet : Bullet
{
    protected override void BulletFly()
    {
        transform.localScale *= 1.01f;
    }

    private void OnDestroy()
    {
        Debug.Log("destroy");
    }
}
