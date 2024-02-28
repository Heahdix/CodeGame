using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public EnemyData enemyData;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            Damage dmg = new Damage
            {
                damageAmount = enemyData.damage,
                pushForce = enemyData.pushbackStrength,
                origin = transform.position
            };

            other.SendMessage("ReceiveDamage", dmg);
            Destroy(obj: gameObject);

        }

    }
}
