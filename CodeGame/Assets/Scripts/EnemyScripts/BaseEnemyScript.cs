using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseEnemyScript : Fighter
{
    public EnemyData enemyData;

    public override void Start()
    {
        base.Start();
        hitpoint = enemyData.maxHitpoint;
    }
}
