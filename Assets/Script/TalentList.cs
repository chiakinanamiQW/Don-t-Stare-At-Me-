using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TalentList", menuName = "data/TalentList")]


public class TalentList : ScriptableObject
{
    public List<Talent> Talentbag;

    public Talent GetTalent(int ID)
    {
        for (int i = 0; i < Talentbag.Count; i++)
        {
            if (Talentbag[i].talentID == ID)
            {
                return Talentbag[i];
            }
        }

        return null;
    }
}
