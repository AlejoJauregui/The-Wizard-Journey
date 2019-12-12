﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class UIManager : MonoBehaviour
{
    public Slider playerHealthbar;
    public Text playerHealthText;
    public Text playerLevelText;

    public HealthManager playerHealthManager;
    public CharacterStats characterStatsManager;

    public static bool uiManagerCreated;
    
    void Start()
    {
        IsUIManagerCreated();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLife();
        UpdateLevel();
    }
    void UpdateLife()
    {
        //Si subes de nível
        playerHealthbar.maxValue = playerHealthManager.maxHealth;
        playerHealthbar.value = playerHealthManager.currentHealth;

        StringBuilder constructHealthText = new StringBuilder("Life: ");
        constructHealthText.Append(playerHealthManager.currentHealth);
        constructHealthText.Append("/");
        constructHealthText.Append(playerHealthManager.maxHealth);
        playerHealthText.text = constructHealthText.ToString();
    }
    void UpdateLevel()
    {
        StringBuilder constructLevelText = new StringBuilder("Player Level: ");
        constructLevelText.Append(characterStatsManager.currentLevel);
        playerLevelText.text = constructLevelText.ToString();
    }
    void IsUIManagerCreated()
    {
        if(!uiManagerCreated)
        {
            uiManagerCreated = true;
            DontDestroyOnLoad(this.transform.gameObject);
        }
        else   
            Destroy(gameObject);
    }
}
