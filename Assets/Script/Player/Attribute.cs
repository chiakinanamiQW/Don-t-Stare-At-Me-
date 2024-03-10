using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribute : MonoBehaviour
{
    [Header("基础属性")]
    public PlayerData PlayerData;
    public float Health;
    [Header("无敌帧")]
    public float invulnerableDuration;
    public float invulnerableCounter;
    public bool invulnerable;
    private void Start()
    {
        Health = PlayerData.Health;
    }
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
    public void TakeDamage(Enemy enemy) 
    {
        Debug.Log("进来TakeDamage函数了");
        if(invulnerable)
        {
            return;
        }
        if (PlayerData.Health - enemy.EnemyData.PhyDamage >= 0)
        {
            PlayerData.Health -= enemy.EnemyData.PhyDamage;
            Health = PlayerData.Health;
            TriggerInvulnerable();
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
