using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable objects/Player object", fileName = "New player object")]
public class PlayerData : ScriptableObject
{
    [field: Tooltip("Max hitpoints of the player")]
    public int maxHitpoint;

    [field: Tooltip("Max mana of the player")]
    public int maxMana;

    [field: Tooltip("Invulnerable time after hit")]
    public float invulnerable;
}
