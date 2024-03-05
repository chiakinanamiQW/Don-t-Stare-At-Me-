using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="PlayerData",menuName ="data/PlayerData")]

public class PlayerData : ScriptableObject
{/**********������ֵ*************/
    public int MaxHealth;
    public int Health;
    public int MaxSP;
    public int SP;
    /**********�˺�************/
    public float PhyDamage;
    public float MaDamage;
    public float GunDamage;
    public float MissRate;
    public float CriticalRate;
    /***********״̬***********/
    public bool isPoisoned;
    public bool isBlood;
    public bool isCold;

}
