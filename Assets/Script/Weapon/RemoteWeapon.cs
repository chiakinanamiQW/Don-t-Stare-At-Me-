using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RemoteWeapon : Weapon
{
    public GameObject WeaponBullet;//武器对应射弹
    public float fireFrequency;//攻击频率 次每秒

    [SerializeField]protected bool canFire;
    [SerializeField]protected float canfireCounter;

    public  override void Attack()
    {
        base.Attack();
        if (canFire)
        {
            if(fireFrequency == 0)
            {
                canfireCounter = 0;
            }
            else
            {
                canfireCounter = 1 / fireFrequency;
            }
            canFire = false;
            Instantiate(WeaponBullet, transform.position, transform.rotation);
        }
    }

    protected override void Update()
    {
        base.Update();

        if(!canFire) 
        {
            canfireCounter -= Time.deltaTime;

            if(canfireCounter <= 0)
            {
                canFire = true;
                canfireCounter = 0;
            }
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        Debug.Log("RemoteWeapon can cause touch damage");
    }
}
