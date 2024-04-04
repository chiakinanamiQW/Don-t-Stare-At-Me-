using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField]protected float existTime;

    [SerializeField] protected float flySpeed;

    [SerializeField] protected Vector2 direction;

    [SerializeField] public Attribute playerattribute;

    [SerializeField] protected Rigidbody2D rigidbody2d;
    protected virtual void Awake()
    {
        GameObject player = GameObject.Find("Player");
        direction = player.GetComponent<PlayerDirection>().PlayerMousePoint;
        playerattribute = player.GetComponent<Attribute>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        Debug.Log("biu~biu~biu");
        Destroy(this.gameObject, existTime);
    }

    protected virtual void FixedUpdate()
    {
        BulletFly();
    }

    protected abstract void BulletFly();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Debug.Log("Damage");
            collision.gameObject.GetComponent<Enemy>()?.TakeDamage(playerattribute);
        }
    }
}
