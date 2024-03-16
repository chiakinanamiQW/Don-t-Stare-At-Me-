using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TalentList", menuName = "data/TalentList")]


public class TalentList : ScriptableObject
{
    public List<TalentData> talentsList;

    public static TalentData GetRandomTalentInList(TalentList list)
    {
        TalentData resulttalent;

        resulttalent = list.talentsList[Random.Range(0, list.talentsList.Count)];

        return resulttalent;
    }
}
