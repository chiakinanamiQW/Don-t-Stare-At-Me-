using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TalentManager : MonoBehaviour
{
  

    public static TalentManager instance;

    [SerializeField] private Attribute attribute;
    [SerializeField] private Button[] talentButtons = new Button[3];
    public TalentList talentList;
    public TalentData[] talentDatas = new TalentData[3];

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

 
    }

    private void Start()
    {
        attribute = GameObject.Find("Player").GetComponent<Attribute>();
    }
    public void TalentChoiceState()
    {
        TalentUIEnable();
        getRandomTalentList();
    }

    public void getRandomTalentList()
    {
        for(int i = 0;i < 3; i++)
        {
            talentDatas[i] = TalentList.GetRandomTalentInList(talentList);
            ChangeButtonUI(i);
        }
    }

    private void ChangeButtonUI(int i)
    {
        talentButtons[i].image.sprite = talentDatas[i].talentSprite;
        talentButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = talentDatas[i].talentName;
        talentButtons[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = talentDatas[i].talentDescription;
    }


    public void TalentUIEnable()
    {
        for(int i = 0; i<3; i++) 
        {
            talentButtons[i].gameObject.SetActive(true);

        }
    }

    public void TalentUIUnable()
    {
        for (int i = 0; i < 3; i++)
        {
            talentButtons[i].gameObject.SetActive(false);

        }
    }
 
    #region ButtonÌì¸³Ó¦ÓÃ
    public void ApplyRandomTalent0()
    {
        attribute.ApplyAddition(talentDatas[0]);
        TalentUIUnable();
    }

    public void ApplyRandomTalent1() 
    {
        attribute.ApplyAddition(talentDatas[1]);
        TalentUIUnable();

    }

    public void ApplyRandomTalent2() 
    {
        attribute.ApplyAddition(talentDatas[2]);
        TalentUIUnable();
    }
    #endregion
}
