using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{  

    public int damage;
    //reference to the principal character
    GameObject thePlayer;

    private void OnCollisionEnter2D(Collision2D player)
    {
        if(player.gameObject.tag.Equals("Player"))
        {
            //Collision between enemy and player
            player.gameObject.GetComponent<HealthManager>().CalculateDamage(damage);
            
        }   
    }

}
