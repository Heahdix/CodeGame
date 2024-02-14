using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseEnemyScript : Fighter
{
    public FighterData fighterData;

    public override void Start()
    {
        base.Start();
        hitpoint = fighterData.maxHitpoint;
    }

    protected override void ReceiveDamage(Damage dmg)
    {
        base.ReceiveDamage(dmg);
    }

    protected override void Death()
    {
        Destroy(gameObject);
    }
}
