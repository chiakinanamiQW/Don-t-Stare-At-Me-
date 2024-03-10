using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public int totalTalent;

    public int index = 3;

    public int[] random;

    public TalentList talentList;

    public Talent[] talents;

    private void Awake()
    {
        random = new int[index];
        talents = new Talent[index];
    }
    public void SummonIntotal()
    {
        int a = 0;//ÖØ¸´´ÎÊý

        while (true)
        {
            if(totalTalent <index)
            {
                //Debug.Log("totalTalent"+ totalTalent);
                break;
            }
            Debug.Log("Try Summon!");

            for (int i = 0; i < random.Length; i++)
            {
                random[i] = Random.Range(0, totalTalent);
            }

            for(int i = 0;i < random.Length; i++)
            {
                for(int j = i +1;j< random.Length;j++)
                {
                    if (random[i] == random[j])
                    {
                        a++;
                    }

                }
            }

            if(a >0)
            {
                Debug.Log(a);
                a = 0;
                continue;
            }
            break;
        }

        GetTalents();

    }

    public void GetTalents()
    {
        for(int i = 0; i < random.Length; i++)
        {
            talents[i] = talentList.GetTalent(random[i]);
        }
    }




    //public void Summon(List<Talent> talentlist)
    //{
    //    int R = Random.Range(0, random.Length);

    //    int a = Random.Range(0,talentlist.Count);
        
    //}
}
