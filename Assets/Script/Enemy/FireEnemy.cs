using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemy : MonoBehaviour
{
    public float PhyDamage;//子弹物理伤害
    public float MaDamage;//子弹法术伤害
    public string Bullet;

    private GameObject bulletPrefab;
    private bool isFire = true;//用于处理动画状态机
    public Rigidbody2D rb;
    public Animator animator;

    public float BulletSpeed;
    public float angle;
    [Header("射击间隔")]
    public int ShotNums;
    public float fireDuration;
    public float fireTimer;
    public bool Fireable;
    private void Start()
    {
        bulletPrefab = (GameObject)Resources.Load("Prefabs/Bullet");
        Debug.Log(bulletPrefab);
    }
    private void Update()
    {
        fireTimer += Time.deltaTime;
        if (fireTimer >= fireDuration)
        {
            for(int i = 0; i < ShotNums; i++)
            {
                Fire();
            }
        }
        fireTimer = 0;
    }
    public void Fire()
    {
        Vector3 target = rb.transform.position;
        Vector3 direction = (transform.position - target).normalized;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * BulletSpeed;
    }
 
   
}
