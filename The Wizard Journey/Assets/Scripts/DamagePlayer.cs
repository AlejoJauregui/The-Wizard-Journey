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
            //Collision between enemy and player
            objCollision.gameObject.GetComponent<HealthManager>().CalculateDamage(damage);
            
            var clone = (GameObject) Instantiate(damageNumber, objCollision.gameObject.transform.position,Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumber>().damagePoints = damage;
        }   
    }

}
