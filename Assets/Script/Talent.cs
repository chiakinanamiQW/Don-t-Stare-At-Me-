using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Talent", menuName = "data/Talent")]

public class Talent : ScriptableObject
{
    public int talentID;

    public int MaxHealthPlus;
    public int MaxSPPlus;
    public float SpeedPlus;
    public float PhyDamagePlus;
    public float MaDamagePlus;
    public float GunDamagePlus;
    public float MissRatePlus;
    public float CriticalRatePlus;

    public void talentapply(Talent talent)
    {
        
    }
}
