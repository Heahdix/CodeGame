using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Fighter
{
    public PlayerData playerData;
    public Bar healthBar;
    public ManaSystem manaSystem;

    private bool isInvulnerable = false;
    private float currentDashTime = 0f;

    public override void Start()
    {
        base.Start();
        hitpoint = playerData.maxHitpoint;
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
        while (timer < playerData.invulnerable)
        {
            yield return null;
            timer += Time.deltaTime;
        }
        isInvulnerable = false;
    }

    private void Dash(string direction)
    {
        switch (direction)
        {
            case "l":
                StartCoroutine(Dashing(new Vector2 { x = -1, y = 0 }));
                break;
            case "r":
                StartCoroutine(Dashing(new Vector2 { x = 1, y = 0}));
                break;
            case "d":
                StartCoroutine(Dashing(new Vector2 { x = 0, y = -1}));
                break;
            case "u":
                StartCoroutine(Dashing(new Vector2 {  x = 0, y = 1 }));
                break;
            case "ul":
                StartCoroutine(Dashing(new Vector2 { x = -1, y = 1 }));
                break;
            case "ur":
                StartCoroutine(Dashing(new Vector2 { x = 1, y = 1}));
                break;
            case "dl":
                StartCoroutine(Dashing(new Vector2 { x = -1, y = -1 }));
                break;
            case "dr":
                StartCoroutine(Dashing(new Vector2 { x = 1, y = -1 }));
                break;
        }
    }

    IEnumerator Dashing(Vector2 direction)
    {
        currentDashTime = playerData.dashTime;

        while (currentDashTime > 0)
        {
            currentDashTime -= Time.deltaTime;

            direction.Normalize();

            rb.velocity = direction * playerData.dashSpeed;

            yield return null;
        }

        rb.velocity = Vector2.zero;
    }

    protected override void Death()
    {
        Destroy(gameObject);
    }

}
