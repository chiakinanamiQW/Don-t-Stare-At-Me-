using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    public PlayerData PlayerData;
    public  Text timeText;
    private bool isTimeOut = false;
    [SerializeField] float timer;
    private float timerTime;
    public bool isFinshed;
    private void Start()
    {
        timerTime = timer;
    }
    private void Update()
    {
        _Timer();

    }

    private void _Timer()
    {
        if (!isTimeOut)
        {
            timer-=Time.deltaTime;
            timeText.text=timer.ToString("F0");
            if(timer <= 0)
            {
                isTimeOut = true;
                timerTime += 5;
                timer = timerTime;
                if (!PlayerData.isDead) { isTimeOut = false; }
            }
        }
    }
}
