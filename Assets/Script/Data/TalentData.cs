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
    public float GunDamageAddition;
    public float MissRateAddition;
    public float CriticalRateAddition;

    public enum TalentType
    {
        a,
        b,
        c,
    }

    public static void ApplyTalent(TalentData talent) 
    {
        Debug.Log("Talent Applying Wait to Do!"+"\n"+talent.talentName+"\n" +talent.talentID);
    }
}
