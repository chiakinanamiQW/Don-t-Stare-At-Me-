using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Attribute : MonoBehaviour
{
    [Header("基础属性")]
    /**********基础数值*************/
    public float MaxHealth;
    public float Health ;

    public float MaxSan;
    public float San;//精神值

    public float PhyDamage;
    public float MaDamage;

    public float MissRate;//闪避率
    public float PhyDenfend;//物理防御
    public float MaDenfend;//法术防御

    public float Speed;

    public float CriticalRate;
    public float CriticalDamageMagnification;

    [Header("无敌帧")]
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
        if (invulnerable == true)//如果处于无敌帧 将不会扣血
            return;
        if (Health - enemy.PhyDamage >= 0)//为防止血条变负数
        {
            Health -= enemy.PhyDamage;//掉血
            TriggerInvulnerable();//掉血后，让后让玩家重新进入无敌帧状态          
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

        if (invulnerable == true)//如果处于无敌帧 将不会扣血
            return;
        if (Health - phyDamage >= 0)//为防止血条变负数
        {
            Health -= phyDamage;//掉血
            TriggerInvulnerable();//掉血后，让后让玩家重新进入无敌帧状态          
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
