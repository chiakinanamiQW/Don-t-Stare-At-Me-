using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyData", menuName = "data/EnemyData")]
public class EnemyData : ScriptableObject
{
    public int MaxHealth;
    public int Health;
    public float PhyDamage;
    public float MaDamage;
    public float GunDamage;
    public bool isPoisoned;
    public bool isBlood;
    public bool isCold;
}
