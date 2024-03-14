using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Attribute : MonoBehaviour
{
    [Header("基础属性")]
    /**********基础数值*************/
    public float MaxHealth;
    public float Health ;
    public float MaxSan;
    public float San;//精神值
    public float MissRate;//闪避率
    public float PhyDenfend;//物理防御
    public float MaDenfend;//法术防御

    [Header("无敌帧")]
    public float invulnerableDuration;
    public float invulnerableCounter;
    public bool invulnerable;
 
    private void Update()
    {
        if(invulnerable)
        {
            invulnerableCounter-=Time.deltaTime;
            if(invulnerableCounter <= 0)
            {
                invulnerable = false;
            }
        }
    }
    private void Awake()
    {
        Health = MaxHealth;
    }
    public void TakeDamage(Enemy enemy) 
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
    public void TakeDamage(EnemyBullet enemy)
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

    private void TriggerInvulnerable()
    {
        if(!invulnerable)
        {
            invulnerable = true;
            invulnerableCounter = invulnerableDuration;
        }
    }
}
