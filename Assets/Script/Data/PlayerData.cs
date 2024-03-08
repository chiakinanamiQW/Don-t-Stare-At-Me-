using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="PlayerData",menuName ="data/PlayerData")]

public class PlayerData : ScriptableObject
{/**********»ù´¡ÊýÖµ*************/
    public int InitialMaxHealth;
    public int InitialMaxSP;
    public float InitialSpeed;
    /**********ÉËº¦************/
    public float InitialPhyDamage;
    public float InitialMaDamage;
    public float InitialGunDamage;
    public float InitialMissRate;
    public float InitialCriticalRate;
}
