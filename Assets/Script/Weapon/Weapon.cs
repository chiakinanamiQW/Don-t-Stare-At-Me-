using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [Header("�������Լӳ�")]
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

    [Header("����")]
    [SerializeField]protected Vector2 mouseDirection;//��귽��
    [SerializeField] protected Attribute playerAttribute;
    [SerializeField] protected GameObject player;
    [SerializeField] protected Animator animator;
    //public Vector3 summonPosition;//ʹ������ʱ�����������ҵ�λ��

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

    public virtual void EquipWeapenAddition(Attribute playerAttribute)//װ��ʱ�����Լӳ�
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

    public virtual void UnloadWeapenAddition( Attribute playerAttribute) //ж��ʱ��ȥ���Լӳ�
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

    public virtual void WeaponGrow(Attribute playerAttribute)//������С����������
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
