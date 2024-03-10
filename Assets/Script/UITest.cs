using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITest : MonoBehaviour
{
    public Talent talent;

    public int ID;

    public test test_t;

    public TalentList talentList;

    public PlayerData playerData;

    private void Awake()
    {
        test_t = GameObject.Find("GameObject").GetComponent<test>();
    }

    public void AbsTest()
    {
        talent = test_t.talents[0];
    }
}
