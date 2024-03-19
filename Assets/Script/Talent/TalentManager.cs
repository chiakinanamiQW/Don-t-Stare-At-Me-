using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TalentManager : MonoBehaviour
{
    public static TalentManager instance;
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

    #region Button�츳Ӧ��
    public void ApplyRandomTalent0()
    {
        TalentData.ApplyTalent(talentDatas[0]);
    }

    public void ApplyRandomTalent1() 
    {
        TalentData.ApplyTalent(talentDatas[1]);

    }

    public void ApplyRandomTalent2() 
    {
        
        TalentData.ApplyTalent(talentDatas[2]);

    }
    #endregion
}
