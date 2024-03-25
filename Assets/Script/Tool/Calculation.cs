using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Calculation
{
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

    public static float calculateFinalMaDamage(float MaDamage, float CriticalRate, float CriticalDamageMagnification, float ememyMaDenfend)
    {
        float finalPhyDamage;
        finalPhyDamage = 0;

        float BasicPhyDamage;
        BasicPhyDamage = MaDamage - ememyMaDenfend;

        if (BasicPhyDamage < 0)
        {
            BasicPhyDamage = 1;
        }

        if (Probability.SetProbabilityEventSingle(CriticalRate))
        {
            finalPhyDamage = BasicPhyDamage * CriticalDamageMagnification;
        }
        else
        {
            finalPhyDamage = BasicPhyDamage;
        }

        return finalPhyDamage;
    }
}
