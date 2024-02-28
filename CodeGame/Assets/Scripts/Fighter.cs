using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    protected Rigidbody2D rb;

    protected int hitpoint;

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void ReceiveDamage(Damage dmg)
    {
        hitpoint -= dmg.damageAmount;

        Vector2 currentPostition;
        currentPostition.x = transform.position.x;
        currentPostition.y = transform.position.y;
        Vector3 pushDirection = (currentPostition - dmg.origin).normalized * dmg.pushForce;

        if (hitpoint <= 0)
        {
            hitpoint = 0;
            Death();
        }

        rb.AddForce(pushDirection, ForceMode2D.Impulse);
    }

    protected virtual void Death()
    {
        Destroy(gameObject);

    }
}

