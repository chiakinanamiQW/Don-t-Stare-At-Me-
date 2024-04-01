using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WoodenStick : Weapon
{
    private int i = 0;

    protected override void Awake()
    {
        base.Awake();
        StartCoroutine(iDown());
    }
    public override void Attack()
    {
        base.Attack();
        i++;
        if(i >= 1 && i < 2)
        {
            Debug.Log("i >= 1 && i < 2 ");
            animator.SetTrigger("Attack");
        }
        else if(i >= 2)
        {
            Debug.Log("i >= 2");
            animator.SetTrigger("Attack");
        }

        if(i > 2)
        {
            i = 0;
        }
    }

    public void OnDestroy()
    {
        StopCoroutine(iDown());
    }
    IEnumerator iDown()
    {
        while(true) 
        {
            if(i >= 1)
            {
                i--;
            }
            Debug.Log(i);
            yield return new WaitForSeconds(0.5f);
        }
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("Damage");
            collision.gameObject.GetComponent<Enemy>().TakeDamage(playerAttribute);
        }
    }
}
