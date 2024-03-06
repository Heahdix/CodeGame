using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public EnemyData enemyData;
    public float bulletSpeed = 1f;
    
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.velocity = -1 * bulletSpeed * transform.right;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall")) 
        {
            Destroy(obj: gameObject);
        }
        else if (other.CompareTag("Player"))
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
