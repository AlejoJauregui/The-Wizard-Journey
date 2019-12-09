using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public int weaponDamage;
    public GameObject hurtAnimation;
    public GameObject hitPoint;
    public GameObject damageNumber; 
    private void OnTriggerEnter2D(Collider2D objCollision) 
    {
        if(objCollision.gameObject.tag.Equals("Enemy"))
        {
            objCollision.gameObject.GetComponent<HealthManager>().CalculateDamage(weaponDamage);
            Instantiate(hurtAnimation, hitPoint.transform.position, hitPoint.transform.rotation);

            var clone = (GameObject)Instantiate(damageNumber,hitPoint.transform.position,Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumber>().damagePoints = weaponDamage;
        }
    }
}
