using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Attribute : MonoBehaviour
{
    [Header("��������")]
    /**********������ֵ*************/
    public float MaxHealth;
    public float Health ;

    public float MaxSan;
    public float San;//����ֵ

    public float PhyDamage;
    public float MaDamage;

    public float MissRate;//������
    public float PhyDenfend;//�������
    public float MaDenfend;//��������

    public float Speed;

    public float CriticalRate;
    public float CriticalDamageMagnification;

    [Header("�޵�֡")]
    public float invulnerableDuration;
    public float MaxinvulnerableDuration;
    public float invulnerableCounter;
    public bool invulnerable;

    protected virtual void Update()
    {
        //if(invulnerable)
        //{
        //    Debug.Log("invulnerable update");
        //    invulnerableCounter -= Time.deltaTime;
        //    if(invulnerableCounter <= 0)
        //    {
        //        Debug.Log("invulnerableCounter");
        //        invulnerable = false;
        //    }
        //}
        if(invulnerable == true)
        {
            Debug.Log(invulnerable);
            invulnerableCounter -= Time.deltaTime;

            if(invulnerableCounter <= 0 )
            {
                invulnerable = false;
                invulnerableCounter = 0;
            }
        }

    }
    private void Awake()
    {
        Health = MaxHealth;
    }

    public void ApplyTalent(TalentData talentData)
    {
        MaxHealth += talentData.MaxHealthAddition;
        MaxSan += talentData.MaxSanAddition;

        PhyDamage += talentData.PhyDamageAddition;
        MaDamage += talentData.MaDamageAddition;

        MissRate += talentData.MissRateAddition;
        PhyDenfend += talentData.PhyDenfendAddition;
        MaDenfend += talentData.MaDenfendAddition;

        Speed += talentData.SpeedAddition;

        CriticalRate += talentData.CriticalRateAddition;
        CriticalDamageMagnification += talentData.CriticalDamageMagnificationAddition;

        if(invulnerableDuration + talentData.invulnerableDurationAddition > MaxinvulnerableDuration)
        {
            invulnerableDuration = MaxinvulnerableDuration;
        }
        else
        {
            invulnerableDuration += talentData.invulnerableDurationAddition;
        }

        Debug.Log("Apply talent:" + talentData.name + "successfully!");
    }
    public void TakeDamage(Atk enemy) 
    {
        if (invulnerable == true)//��������޵�֡ �������Ѫ
            return;
        if (Health - enemy.PhyDamage >= 0)//Ϊ��ֹѪ���为��
        {
            Health -= enemy.PhyDamage;//��Ѫ
            TriggerInvulnerable();//��Ѫ���ú���������½����޵�֡״̬          
        }
        else
        {
            Health = 0;
        }
    }

    public void TakeDamage(Attribute attacker)
    {
        float phyDamage = 0;
        phyDamage = Calculation.calculateFinalPhyDamage(attacker, this);

        if (invulnerable == true)//��������޵�֡ �������Ѫ
            return;
        if (Health - phyDamage >= 0)//Ϊ��ֹѪ���为��
        {
            Health -= phyDamage;//��Ѫ
            TriggerInvulnerable();//��Ѫ���ú���������½����޵�֡״̬          
        }
        else
        {
            Health = 0;
        }
    }
   
    private void TriggerInvulnerable()
    {
        if(!invulnerable)
        {
            invulnerable = true;
            invulnerableCounter = invulnerableDuration;
        }
    }
}
