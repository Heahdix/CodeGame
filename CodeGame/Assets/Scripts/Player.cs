using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Fighter
{
    public PlayerData playerData;
    public Bar healthBar;
    public ManaSystem manaSystem;

    private bool _isInvulnerable = false;
    private float _currentDashTime = 0f;

    public override void Start()
    {
        base.Start();
        hitpoint = playerData.maxHitpoint;
        healthBar.SetMaxValue(hitpoint);
        manaSystem.SetMaxMana(playerData.maxMana);
    }

    void Update()
    {
    }

    protected override void ReceiveDamage(Damage dmg)
    {
        if (!_isInvulnerable)
        {
            base.ReceiveDamage(dmg);

            healthBar.SetValue(hitpoint);

            StartCoroutine(Invulnerable());
        }
        else
        {
            dmg.damageAmount = 0;

            base.ReceiveDamage(dmg);
        }
    }
    
    IEnumerator Invulnerable()
    {
        _isInvulnerable = true;
        float timer = 0;
        while (timer < playerData.invulnerable)
        {
            yield return null;
            timer += Time.deltaTime;
        }
        _isInvulnerable = false;
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
        _currentDashTime = playerData.dashTime;

        while (_currentDashTime > 0)
        {
            _currentDashTime -= Time.deltaTime;

            direction.Normalize();

            rb.velocity = direction * playerData.dashSpeed;

            yield return null;
        }

        rb.velocity = Vector2.zero;
    }
}
