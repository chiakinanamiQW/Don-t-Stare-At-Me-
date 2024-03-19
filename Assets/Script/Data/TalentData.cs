using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TalentData", menuName = "data/TalentData")]


public class TalentData : ScriptableObject
{
    [Header("天赋")]
    public string talentName;
    public string talentDescription;
    public int talentID;
    public TalentType talentType;

    public Sprite talentSprite;


    [Header("天赋加成")]
    public float MaxHealthAddition;
    public float MaxSanAddition;

    public float PhyDamageAddition;
    public float MaDamageAddition;

    public float MissRateAddition;
    public float PhyDenfendAddition;
    public float MaDenfendAddition;

    public float SpeedAddition;

    public float CriticalRateAddition;
    public float CriticalDamageMagnificationAddition;

    public float invulnerableDurationAddition;
    public enum TalentType
    {
        a,
        b,
        c,
    }
}
