using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{  

    public int damage;

    public GameObject damageNumber; 
    //reference to the principal character
    GameObject thePlayer;

    private void OnCollisionEnter2D(Collision2D objCollision)
    {
        if(objCollision.gameObject.tag.Equals("Player"))
        {
            CharacterStats stats = objCollision.gameObject.GetComponent<CharacterStats>();
            int totalDamage = damage - stats.defenseLevels[stats.currentLevel];

            if(totalDamage <= 0)
                totalDamage = 1;

            //Collision between enemy and player
            objCollision.gameObject.GetComponent<HealthManager>().CalculateDamage(totalDamage);
            
            var clone = (GameObject) Instantiate(damageNumber, objCollision.gameObject.transform.position,Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumber>().damagePoints = totalDamage;
        }   
    }

}
