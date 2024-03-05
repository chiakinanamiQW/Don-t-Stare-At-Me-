using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="PlayerData",menuName ="data/PlayerData")]

public class PlayerData : ScriptableObject
{/**********»ù´¡ÊýÖµ*************/
    public int MaxHealth;
    public int Health;
    public int MaxSP;
    public int SP;
    /**********ÉËº¦************/
    public float PhyDamage;
    public float MaDamage;
    public float GunDamage;
    public float MissRate;
    public float CriticalRate;
    /***********×´Ì¬***********/
    public bool isPoisoned;
    public bool isBlood;
    public bool isCold;

}
