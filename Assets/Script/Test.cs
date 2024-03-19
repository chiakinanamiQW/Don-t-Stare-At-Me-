using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float[] probabilitys = new float[4];
    public void test1()
    {
        float a;
        for(int i = 0;i<200;i++)
        {
            a = Calculation.calculateFinalPhyDamage(1000, 0.5f, 2, 400);
            Debug.Log(a);
        }
    }

    public void testProbability()
    {
        for(int i = 0; i < 100; i++)
        {
            Debug.Log(Probability.SetProbabilityEventComplex(probabilitys));
        }
    }
}
