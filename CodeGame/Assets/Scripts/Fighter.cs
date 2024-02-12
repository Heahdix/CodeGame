using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public EnemyData enemyData;

    public int hitpoint;
    //public float pushrecoverySpeed;

    //protected float immuneTime;
    //protected float lastImmune;

    protected Vector3 pushDirection;

    public virtual void Awake()
    {
        hitpoint = enemyData.maxHitpoint;
    }

    protected virtual void RecieveDamage(Damage dmg)
    {
        //if (Time.time - lastImmune > immuneTime)
        //{
        //    lastImmune = Time.time;
        hitpoint -= dmg.damageAmount;
        pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

        //    //GameManager.instance.ShowText(dmg.damageAmount.ToString(), 25, Color.red, transform.position, Vector3.zero, 0.5f);

        if (hitpoint <= 0)
        {
            hitpoint = 0;
            Death();
        }
    }

    protected virtual void Death()
    {

    }
}

