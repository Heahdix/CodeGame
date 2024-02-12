using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable objects/Weapon object", fileName = "New weapon object")]
public class WeaponData : ScriptableObject, ISerializationCallbackReceiver
{
    //[field: SerializeField]
    //[Tooltip("Prefab of weapon")]
    //private GameObject _prefab;

    [field: SerializeField]
    [field: Tooltip("Sprite for weapon")]
    public Sprite _sprite;


    [field: Tooltip("Initial damage of the weapon per hit")]
    public int initialDamage;

    [field: NonSerialized]
    [field: Tooltip("Damage of the weapon per hit")]
    public int damage;

    [field: Tooltip("Pushback strength of the weapon")]
    public float pushbackStrength;

    [field: Tooltip("Initial attack speed if weapon")]
    public float initialSpeed;

    [field: NonSerialized]
    [field: Tooltip("Initial speed if weapon")]
    public float speed;

    [field: Tooltip("Initial size of the progectile/melee attack")]
    public float initialSize;

    [field: NonSerialized]
    [field: Tooltip("Size of the progectile/melee attack")]
    public float size;

    [field: SerializeField]
    [field: Tooltip("Coef for RAM usage")]
    protected float _coef;

    [field: Tooltip("Value of RAM using per cast")]
    protected float _ramUsage;

    //public GameObject Prefab => this._prefab;
    public Sprite Sprite => this._sprite;
    public float RamUsage => this._ramUsage;

    public enum TargetValue
    {
        Closest,
        Farthest,
        WithMostHP
    }

    public virtual void SetRamUsage()
    {
        _ramUsage = damage * size * _coef;
    }

    public void OnAfterDeserialize()
    {
        damage = initialDamage;
        size = initialSize;
        speed = initialSpeed;
    }

    public void OnBeforeSerialize()
    {

    }


}
