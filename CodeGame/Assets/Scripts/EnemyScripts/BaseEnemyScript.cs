using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseEnemyScript : Fighter
{
    public int damage;
    public float speed;
    public float pushbackStrength;
    public float range;
    public float pushRecoverySpeed;

    public override void Awake()
    {
        base.Awake();
        damage = enemyData.damage;
        speed = enemyData.speed;
        pushbackStrength = enemyData.pushbackStrength;
        range = enemyData.range;
        pushRecoverySpeed = enemyData.pushRecoverySpeed;
    }

    protected override void Death()
    {
        Destroy(gameObject);
    }
}
