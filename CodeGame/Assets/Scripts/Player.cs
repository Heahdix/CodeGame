using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Fighter
{
    public PlayerData playerData;
    public Bar healthBar;
    public ManaSystem manaSystem;

    private float recoveryTime;
    private bool isInvulnerable = false;

    public override void Start()
    {
        base.Start();
        hitpoint = playerData.maxHitpoint;
        recoveryTime = playerData.invulnerable;
        healthBar.SetMaxValue(hitpoint);
        manaSystem.SetMaxMana(playerData.maxMana);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Damage dmg = new Damage
            {
                damageAmount = 20,
                pushForce = 1,
                origin = transform.position
            };
            ReceiveDamage(dmg);
        }
    }

    protected override void ReceiveDamage(Damage dmg)
    {
        if (!isInvulnerable)
        {
            //hitpoint -= dmg.damageAmount;

            //healthBar.SetValue(hitpoint);

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
            base.ReceiveDamage(dmg);

            StartCoroutine(Invulnerable());
        }
    }
    
    IEnumerator Invulnerable()
    {
        isInvulnerable = true;
        float timer = 0;
        while (timer < recoveryTime)
        {
            yield return null;
            timer += Time.deltaTime;
        }
        isInvulnerable = false;
    }

    private void Evade(Direction direction)
    {

    }

    protected override void Death()
    {
        Destroy(gameObject);
    }

    enum Direction
    {
        l,u,r,d,lu,ru,rd,ld
    }
}
