using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]
    public int maxHealth;
    [SerializeField]
    public int currentHealth;

    public bool flashActive;
    public float flashLength;
    private float flashCounter;

    public int expWhenDefeted; 

    private SpriteRenderer characterRenderer;

    
    private SFXManager managerSFX; 

    // Start is called before the first frame update
    void Start()
    {
        managerSFX = FindObjectOfType<SFXManager>();
        currentHealth = maxHealth;
        characterRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        areYouAlive();
        isFlashingModeActive();
    }
    
    void areYouAlive()
    {
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
            if(gameObject.tag.Equals("Enemy"))
            {
                GameObject.Find("Wizard").GetComponent<CharacterStats>().AddExperience(expWhenDefeted);
                managerSFX.demonDead.Play();
            }
            if(gameObject.tag.Equals("Player"))
                managerSFX.playerDead.Play();
        }
    }
    public void CalculateDamage(int damage)
    {
        currentHealth -= damage;
        if(flashLength > 0)
        {
            flashActive = true;
            flashCounter = flashLength;
        }
    }
    
    public void UpdateMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        currentHealth = maxHealth;
    }

    private void ToggleColor(bool visible)
    {
        characterRenderer.color = new Color(characterRenderer.color.r, characterRenderer.color.g, 
            characterRenderer.color.b, (visible?1.0f:0.0f));
    }
    
    void isFlashingModeActive()
    {
        if(flashActive)
        {
            flashCounter -= Time.deltaTime;
            if(flashCounter > flashLength * 0.66)
            {
                ToggleColor(false);
            }
            else if(flashCounter > flashLength * 0.33)
            {
                ToggleColor(true);
            }
            else if(flashCounter > flashLength * 0)
            {
                ToggleColor(false);
            }
            else
            {
                ToggleColor(true);
                flashActive = false;
            }
        }
    }
}
