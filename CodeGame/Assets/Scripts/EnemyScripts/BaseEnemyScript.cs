using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseEnemyScript : Fighter
{
    public EnemyData enemyData;
    public Room observingRoom;

    protected bool _playerInTheRoom = false;

    public override void Start()
    {
        base.Start();
        hitpoint = enemyData.maxHitpoint;
    }

    private void Awake()
    {
        if (observingRoom != null)
        {
            observingRoom.OnPlayerEntered += OnPlayerEntered;
        }
    }

    private void OnDestroy()
    {
        if (observingRoom != null)
        {
            observingRoom.OnPlayerEntered -= OnPlayerEntered;
        }
    }

    protected void OnPlayerEntered()
    {
        _playerInTheRoom = true;
    }
}
