using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float MaxHealthAddition;
    public float MaxSanAddition;

    public float PhyDamageAddition;
    public float MaDamageAddition;

    public float MissRateAddition;
    public float PhyDenfendAddition;
    public float MaDenfendAddition;

    public float SpeedAddition;

    public float CriticalRateAddition;
    public float CriticalDamageMagnificationAddition;

    public float invulnerableDurationAddition;

    [SerializeField] protected Attribute playerAttribute;
    [SerializeField] protected Animator animator;

    private void Awake()
    {
        playerAttribute = GameObject.Find("Player")?.GetComponent<Attribute>();
        animator = GetComponent<Animator>();
        //gameObject.SetActive(false);
    }

    public virtual void EquiPWeapenAddition(Attribute playerAttribute)
    {
        playerAttribute.MaxHealth += MaxHealthAddition;
        playerAttribute.MaxSan += MaxSanAddition;

        playerAttribute.PhyDamage += PhyDamageAddition;
        playerAttribute.MaDamage += MaDamageAddition;

        playerAttribute.MissRate += MissRateAddition;
        playerAttribute.PhyDenfend += PhyDenfendAddition;
        playerAttribute.MaDenfend += MaDenfendAddition;

        playerAttribute.Speed += SpeedAddition;

        playerAttribute.CriticalRate += CriticalRateAddition;
        playerAttribute.CriticalDamageMagnification += CriticalDamageMagnificationAddition;

        if (playerAttribute.invulnerableDuration + invulnerableDurationAddition > playerAttribute.MaxinvulnerableDuration)
        {
            playerAttribute.invulnerableDuration = playerAttribute.MaxinvulnerableDuration;
        }
        else
        {
            playerAttribute.invulnerableDuration += invulnerableDurationAddition;
        }

    }

    public virtual void UnloadWeapenAddition( Attribute playerAttribute) 
    {
        playerAttribute.MaxHealth -= MaxHealthAddition;
        playerAttribute.MaxSan -= MaxSanAddition;

        playerAttribute.PhyDamage -= PhyDamageAddition;
        playerAttribute.MaDamage -= MaDamageAddition;

        playerAttribute.MissRate -= MissRateAddition;
        playerAttribute.PhyDenfend -= PhyDenfendAddition;
        playerAttribute.MaDenfend -= MaDenfendAddition;

        playerAttribute.Speed -= SpeedAddition;

        playerAttribute.CriticalRate -= CriticalRateAddition;
        playerAttribute.CriticalDamageMagnification -= CriticalDamageMagnificationAddition;

        playerAttribute.invulnerableDuration -= invulnerableDurationAddition;
        
    }

    public virtual void Attack()
    {
        
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Debug.Log("Damage");
            collision.gameObject.GetComponent<Enemy>().TakeDamage(playerAttribute);
        }
    }
    
}
