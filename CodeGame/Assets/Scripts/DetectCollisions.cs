using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public WeaponData weaponData;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("hitting enemy");

            // Damage dmg = new Damage()
            // {
            //     damageAmount = weaponData.damage;
            //     pushForce = weaponData.pushbackStrength;
            //     origin = transform.position;
            // }
        }
    }
}
