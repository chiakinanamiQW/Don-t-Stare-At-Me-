using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Calculation
{
    #region 物理伤害计算
    public static float calculateFinalPhyDamage(float phyDamage,float CriticalRate,float CriticalDamageMagnification ,float ememyPhyDenfend)
    {
        float finalPhyDamage;
        finalPhyDamage = 0;

        float BasicPhyDamage;
        BasicPhyDamage = phyDamage - ememyPhyDenfend;

        if(BasicPhyDamage < 0) 
        {
            BasicPhyDamage = 1;
        }

        if(Probability.SetProbabilityEventSingle(CriticalRate))
        {
            finalPhyDamage = BasicPhyDamage * CriticalDamageMagnification;
        }
        else
        {
            finalPhyDamage = BasicPhyDamage;
        }

        return finalPhyDamage;
    }

    public static float calculateFinalPhyDamage(Attribute attacker,Attribute victims)
    {
        float finalPhyDamage;
        finalPhyDamage = 0;

        float BasicPhyDamage;
        BasicPhyDamage = attacker.PhyDamage - victims.PhyDenfend;

        if (BasicPhyDamage < 0)
        {
            BasicPhyDamage = 1;
        }

        if (Probability.SetProbabilityEventSingle(attacker.CriticalRate))
        {
            finalPhyDamage = BasicPhyDamage * attacker.CriticalDamageMagnification;
        }
        else
        {
            finalPhyDamage = BasicPhyDamage;
        }

        return finalPhyDamage;
    }

    public static float calculateFinalPhyDamage(Attribute attacker,Attribute victims,float basicDamageAddition)//附带基础伤害加成
    {
        float finalPhyDamage;
        finalPhyDamage = 0;

        float BasicPhyDamage;
        BasicPhyDamage = attacker.PhyDamage - victims.PhyDenfend;
        BasicPhyDamage *= basicDamageAddition;

        if (BasicPhyDamage < 0)
        {
            BasicPhyDamage = 1;
        }

        if (Probability.SetProbabilityEventSingle(attacker.CriticalRate))
        {
            finalPhyDamage = BasicPhyDamage * attacker.CriticalDamageMagnification;
        }
        else
        {
            finalPhyDamage = BasicPhyDamage;
        }

        return finalPhyDamage;
    }
    #endregion


    #region 魔法伤害计算
    public static float calculateFinalMaDamage(float MaDamage, float CriticalRate, float CriticalDamageMagnification, float ememyMaDenfend)
    {
        float finalMaDamage;
        finalMaDamage = 0;

        float BasicMaDamage;
        BasicMaDamage = MaDamage - ememyMaDenfend;

        if (BasicMaDamage < 0)
        {
            BasicMaDamage = 1;
        }

        if (Probability.SetProbabilityEventSingle(CriticalRate))
        {
            finalMaDamage = BasicMaDamage * CriticalDamageMagnification;
        }
        else
        {
            finalMaDamage = BasicMaDamage;
        }

        return finalMaDamage;
    }

    public static float calculateFinalMaDamage(Attribute attacker,Attribute victims)
    {
        float finalMaDamage;
        finalMaDamage = 0;

        float BasicMaDamage;
        BasicMaDamage = attacker.MaDamage - victims.MaDenfend;

        if (BasicMaDamage < 0)
        {
            BasicMaDamage = 1;
        }

        if (Probability.SetProbabilityEventSingle(attacker.CriticalRate))
        {
            finalMaDamage = BasicMaDamage * attacker.CriticalDamageMagnification;
        }
        else
        {
             finalMaDamage = BasicMaDamage;
        }

        return finalMaDamage;
    }

    public static float calculateFinalMaDamage(Attribute attacker, Attribute victims, float basicDamageAddition)//附带基础伤害加成
    {
        float finalMaDamage;
        finalMaDamage = 0;

        float BasicMaDamage;
        BasicMaDamage = attacker.MaDamage - victims.MaDenfend;
        BasicMaDamage *= basicDamageAddition;

        if (BasicMaDamage < 0)
        {
            BasicMaDamage = 1;
        }

        if (Probability.SetProbabilityEventSingle(attacker.CriticalRate))
        {
            finalMaDamage = BasicMaDamage * attacker.CriticalDamageMagnification;
        }
        else
        {
            finalMaDamage = BasicMaDamage;
        }

        return finalMaDamage;
    }
    #endregion
}
