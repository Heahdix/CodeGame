using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable objects/Weapon object", fileName = "New weapon object")]
public class WeaponData : ScriptableObject, ISerializationCallbackReceiver
{
    [field: SerializeField]
    [field: Tooltip("Initial damage of the weapon per hit")]
    private int _initialDamage;

    [field: NonSerialized]
    [field: Tooltip("Damage of the weapon per hit")]
    public int damage;

    [field: SerializeField]
    [field: Tooltip("Pushback strength of the weapon")]
    private float _initialPushbackStrength;

    [field: NonSerialized]
    [field: Tooltip("Pushback strength of the weapon")]
    public float pushbackStrength;

    [field: SerializeField]
    [field: Tooltip("Initial attack speed if weapon")]
    private float _initialSpeed;

    [field: NonSerialized]
    [field: Tooltip("Initial speed if weapon")]
    public float speed;

    [field: SerializeField]
    [field: Tooltip("Initial size of the progectile/melee attack")]
    private float _initialSize;

    [field: NonSerialized]
    [field: Tooltip("Size of the progectile/melee attack")]
    public float size;

    [field: SerializeField]
    [field: Tooltip("Coef for RAM usage")]
    private float _coef;

    [field: Tooltip("Value of RAM using per cast")]
    private float _ramUsage;

    public float RamUsage => this._ramUsage;

    private void SetRamUsage()
    {
        _ramUsage = damage * size * _coef;
    }

    public void OnAfterDeserialize()
    {
        damage = _initialDamage;
        pushbackStrength = _initialPushbackStrength;
        size = _initialSize;
        speed = _initialSpeed;

        SetRamUsage();
    }

    public void OnBeforeSerialize()
    {

    }


}
