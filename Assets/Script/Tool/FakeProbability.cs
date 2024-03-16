using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeProbability
{
    private int maxFailNum;

    private float probability;

    private int i = 0;

    public FakeProbability(float probability,int maxFailNum)
    {
        this.probability = probability;
        this.maxFailNum = maxFailNum;
    }

    public bool SetFakeProbability()
    {
        if(Probability.SetProbabilityEventSingle(probability)||i>=maxFailNum)
        {
            i = 0;
            return true;
        }
        else
        {
            i++;
            return false;
        }
    }
}
