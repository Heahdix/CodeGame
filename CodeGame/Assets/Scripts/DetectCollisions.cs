using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public WeaponData weaponData;
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Enemy"))
        {

            Damage dmg = new Damage
            {
                damageAmount = weaponData.damage,
                pushForce = weaponData.pushbackStrength,
                origin = transform.position
            };

            other.SendMessage("ReceiveDamage", dmg);

            if (gameObject.CompareTag("Fireball"))
            {
                Destroy(gameObject);
            }
        }
    
    }
}
