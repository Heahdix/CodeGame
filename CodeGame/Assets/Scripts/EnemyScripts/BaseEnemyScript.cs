using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseEnemyScript : Fighter
{
    public override void Awake()
    {
        base.Awake();
    }

    protected override void RecieveDamage(Damage dmg)
    {
        hitpoint -= dmg.damageAmount;
        pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

        if (hitpoint <= 0)
        {
            hitpoint = 0;
            Death();
        }
    }

    protected override void Death()
    {
        Destroy(gameObject);
    }
}
