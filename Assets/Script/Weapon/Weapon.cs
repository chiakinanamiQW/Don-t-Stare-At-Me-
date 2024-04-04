using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [Header("基础属性加成")]
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

    [Header("其它")]
    [SerializeField]protected Vector2 mouseDirection;//鼠标方向
    [SerializeField] protected Attribute playerAttribute;
    [SerializeField] protected GameObject player;
    [SerializeField] protected Animator animator;
    //public Vector3 summonPosition;//使用武器时，武器相对玩家的位置

    protected virtual void Awake()
    {
        
        player = GameObject.Find("Player");
        playerAttribute = player.GetComponent<Attribute>();
        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        mouseDirection = player.GetComponent<PlayerDirection>().PlayerMousePoint;
    }

    public virtual void EquipWeapenAddition(Attribute playerAttribute)//装备时的属性加成
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

    public virtual void UnloadWeapenAddition( Attribute playerAttribute) //卸载时减去属性加成
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

    public virtual void WeaponGrow(Attribute playerAttribute)//武器大小随属性增加
    {
        //Wait to do
    }

    public virtual void Attack()
    {
        this.GetComponent<Collider2D>().enabled = true;
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
