using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandExecutor : MonoBehaviour
{
    public GameObject weaponPrefab;
    public WeaponData weaponData;
    public ManaSystem manaSystem;

    public enum EnemyToAttack
    {
        closest,
        farthest,
        random,
        withMostHp,
        withLeastHp
    }
}
