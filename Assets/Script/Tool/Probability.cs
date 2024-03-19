using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Probability
{
    public static bool SetProbabilityEventSingle(float probability)
    {
        if(probability <0)
        {
            return false;
        }
        else if(probability > 1) 
        {
            return true;
        }

        float randomNum;
        randomNum = Random.Range(0f, 1f);
        if(randomNum<probability)
        {
            return true;
        }
        else
        {
            return false; 
        }
    }

    public static int SetProbabilityEventComplex(float[] probabilitys)
    {
        float randomNum;
        float RangeLimit = 0;
        randomNum = Random.Range(0f, 1f);

        for(int i = 0;i < probabilitys.Length;i++)
        {
            if(randomNum > RangeLimit && randomNum < RangeLimit + probabilitys[i])
            {
                return i;
            }
            else
            {
                RangeLimit += probabilitys[i];
            }
        }
        return -1;
    }
}
