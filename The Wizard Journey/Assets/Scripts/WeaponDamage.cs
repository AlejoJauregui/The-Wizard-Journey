using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    public int weaponDamage;
    public GameObject hurtAnimation;
    public GameObject hitPoint;
    public GameObject damageNumber; 

    private CharacterStats stats;

    void Start()
    {
        stats = transform.parent.GetComponent<CharacterStats>();
    }

    private void OnTriggerEnter2D(Collider2D objCollision) 
    {
        if(objCollision.gameObject.tag.Equals("Enemy"))
        {
            int totalDamage = weaponDamage;
            if(stats != null)
                totalDamage += stats.strengthLevels[stats.currentLevel];

            objCollision.gameObject.GetComponent<HealthManager>().CalculateDamage(totalDamage);
            Instantiate(hurtAnimation, hitPoint.transform.position, hitPoint.transform.rotation);

            var clone = (GameObject)Instantiate(damageNumber,hitPoint.transform.position,Quaternion.Euler(Vector3.zero));
            clone.GetComponent<DamageNumber>().damagePoints = totalDamage;
        }
    }
}
