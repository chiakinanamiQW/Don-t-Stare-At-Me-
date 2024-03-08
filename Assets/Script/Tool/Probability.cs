using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Probability
{
   public static bool CheckProbability(float probability)
    {
        float a = Random.Range(0f,1f);

        if(a<= probability)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

   public static int getListOddsNumber(List<float> probabilitylist)
    {
        float totalProbability = 0;

        foreach(int probability in probabilitylist) 
        {
            totalProbability += probability;
        }

        float randomValue = Random.Range(0f, 1.0f);
        float cumulativeprobability = 0;
        int i = 0;

        for(; i < probabilitylist.Count; i++)
        {
            if(randomValue > cumulativeprobability && randomValue < cumulativeprobability + probabilitylist[i])
            {
                break;
            }
            cumulativeprobability += probabilitylist[i];
        }

        return i;
    }
}
