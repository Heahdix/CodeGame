using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public EnemyData enemyData;

    private void Start()
    {
        enemyData = gameObject.GetComponentInParent<BaseEnemyScript>().enemyData;
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
        }

    }
}
