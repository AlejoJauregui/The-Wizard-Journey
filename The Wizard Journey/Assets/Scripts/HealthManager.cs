﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    int maxHealth;
    [SerializeField]
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        areYouAlive();
    }
    
    void areYouAlive()
    {
        if(currentHealth <= 0)
            gameObject.SetActive(false);
    }
    public void CalculateDamage(int damage)
    {
        currentHealth -= damage;
    }
    public void UpdateMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        currentHealth = maxHealth;
    }
}
