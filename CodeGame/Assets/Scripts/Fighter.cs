using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    protected Rigidbody2D rb;

    protected int hitpoint;
    //public float pushrecoverySpeed;

    //protected float immuneTime;
    //protected float lastImmune;

    protected Vector3 pushDirection;


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
        pushDirection = (currentPostition - dmg.origin).normalized * dmg.pushForce;

        if (hitpoint <= 0)
        {
            hitpoint = 0;
            Death();
        }

        rb.AddForce(pushDirection, ForceMode2D.Impulse);
        //if (Time.time - lastImmune > immuneTime)
        //{
        //    lastImmune = Time.time;
        //hitpoint -= dmg.damageAmount;
        //pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

        //    //GameManager.instance.ShowText(dmg.damageAmount.ToString(), 25, Color.red, transform.position, Vector3.zero, 0.5f);

        //pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, fighterData.pushRecoverySpeed);

        //if (hitpoint <= 0)
        //{
        //    hitpoint = 0;
        //    Death();
        //}

        //hitpoint -= dmg.damageAmount;

        //Vector2 currentPostition;
        //currentPostition.x = transform.position.x;
        //currentPostition.y = transform.position.y;
        //pushDirection = (currentPostition - dmg.origin).normalized * dmg.pushForce;

        //if (hitpoint <= 0)
        //{
        //    hitpoint = 0;
        //    Death();
        //}

        //rb.AddForce(pushDirection, ForceMode2D.Impulse);
    }

    protected virtual void Death()
    {

    }
}

