using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Fighter
{
    public PlayerData playerData;
    public Bar healthBar;
    public ManaSystem manaSystem;
    public Animator animator;

    private bool _isInvulnerable = false;
    private GameManager _gameManager;

    public override void Start()
    {
        base.Start();
        hitpoint = playerData.maxHitpoint;
        healthBar.SetMaxValue(hitpoint);
        manaSystem.SetMaxMana(playerData.maxMana);
        _gameManager = GameManager.instance;
    }

    protected override void ReceiveDamage(Damage dmg)
    {
        if (!_isInvulnerable)
        {
            base.ReceiveDamage(dmg);

            healthBar.SetValue(hitpoint);

            if (hitpoint <= 0)
            {
                _gameManager.GameOver();
            }
            else
            {
                StartCoroutine(Invulnerable());
                animator.SetTrigger("GotHit");
            }
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
               Dashing(new Vector2 { x = -1, y = 0 });
                break;
            case "r":
               Dashing(new Vector2 { x = 1, y = 0});
                break;
            case "d":
               Dashing(new Vector2 { x = 0, y = -1});
                break;
            case "u":
                Dashing(new Vector2 {  x = 0, y = 1 });
                break;
            case "ul":
                Dashing(new Vector2 { x = -1, y = 1 });
                break;
            case "ur":
              Dashing(new Vector2 { x = 1, y = 1});
                break;
            case "dl":
                Dashing(new Vector2 { x = -1, y = -1 });
                break;
            case "dr":
                Dashing(new Vector2 { x = 1, y = -1 });
                break;
        }
    }

    void Dashing(Vector2 direction)
    {
        rb.AddForce(direction * 5, ForceMode2D.Impulse);
    }
}
