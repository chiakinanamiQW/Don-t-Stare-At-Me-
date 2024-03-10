using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController Instance;
    public PlayerData playerData;

    public float maxHealth;
    public float health;

    

    private void Awake()
    {
        if(Instance == null)
            Instance = this;


        maxHealth = playerData.InitialMaxHealth;
        health = maxHealth;
    }

    private void Start()
    {
        
    }
    public void PlayerBeHurt(float finalDamage)
    {
        
    }
}
