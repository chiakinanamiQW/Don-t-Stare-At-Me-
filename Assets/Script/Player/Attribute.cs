using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Attribute : MonoBehaviour
{
    [Header("��������")]
    /**********������ֵ*************/
    public float MaxHealth;
    public float Health ;
    public float MaxSan;
    public float San;//����ֵ
    public float MissRate;//������
    public float PhyDenfend;//�������
    public float MaDenfend;//��������

    [Header("�޵�֡")]
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
    public void TakeDamage(EnemyBullet enemy)
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

    private void TriggerInvulnerable()
    {
        if(!invulnerable)
        {
            invulnerable = true;
            invulnerableCounter = invulnerableDuration;
        }
    }
}
