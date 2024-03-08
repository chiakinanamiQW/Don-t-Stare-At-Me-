using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="PlayerData",menuName ="data/PlayerData")]

public class PlayerData : ScriptableObject
{/**********������ֵ*************/
    public int InitialMaxHealth;
    public int InitialMaxSP;
    public float InitialSpeed;
    /**********�˺�************/
    public float InitialPhyDamage;
    public float InitialMaDamage;
    public float InitialGunDamage;
    public float InitialMissRate;
    public float InitialCriticalRate;
}
