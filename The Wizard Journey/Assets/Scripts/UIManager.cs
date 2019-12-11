using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class UIManager : MonoBehaviour
{
    public Slider playerHealthbar;
    public Text playerHealthText;

    public HealthManager playerHealthManager;

    public static bool uiManagerCreated;
    
    void Start()
    {
        IsUIManagerCreated();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateLife();
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
