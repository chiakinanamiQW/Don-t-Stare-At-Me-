using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField]private float existTime;

    [SerializeField] public Attribute playerattribute;
    protected virtual void Awake()
    {
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
