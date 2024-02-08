using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable objects/Enemy object", fileName = "New enemy object")]
public class EnemyData : ScriptableObject, ISerializationCallbackReceiver
{
    [field: Tooltip("Max hitpoints of the enemy")]
    public int maxHitpoint;

    [field: Tooltip("Push recovery speed")]
    public float pushRecoverySpeed;

    [field: Tooltip("Initial damage of the enemy per hit")]
    public int initialDamage;

    [field: NonSerialized]
    [field: Tooltip("Damage of the enemy per hit")]
    public int damage;

    [field: Tooltip("Pushback strength of the enemy")]
    public float pushbackStrength;

    [field: Tooltip("Initial speed of enemy")]
    public float initialSpeed;

    [field: NonSerialized]
    [field: Tooltip("Speed of enemy")]
    public float speed;

    [field: Tooltip("Range of attack")]
    public float range;

    public void OnAfterDeserialize()
    {
        damage = initialDamage;
        speed = initialSpeed;
    }

    public void OnBeforeSerialize()
    {

    }
}
