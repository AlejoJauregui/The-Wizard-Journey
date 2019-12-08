using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{  

    public int damage;

    GameObject thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D player)
    {
        if(player.gameObject.tag.Equals("Player"))
        {
            //Collision between enemy and player
            player.gameObject.GetComponent<HealthManager>().CalculateDamage(damage);
            
        }   
    }

}
