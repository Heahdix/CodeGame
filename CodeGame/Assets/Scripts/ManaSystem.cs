using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaSystem : MonoBehaviour
{
    public Bar manaBar;

    private float _currentMana;
    private float _maxMana;

    private void Start()
    {
        manaBar = GetComponent<Bar>();
    }

    private void Update()
    {
        if (_currentMana < _maxMana)
        {
            _currentMana = Mathf.MoveTowards(_currentMana, _maxMana, Time.deltaTime * 5f);
            manaBar.SetValue(_currentMana);
        }
    }

    public void SetMaxMana(float value)
    {
        manaBar = GetComponent<Bar>();
        _maxMana = value;
        manaBar.SetMaxValue(_maxMana);
    }
    public bool CanAffordSkill(float value)
    {
        return _currentMana > value;
    }

    public void DecreaseMana(float value)
    {
        _currentMana -= value;
        manaBar.SetValue(_currentMana);
    }
}
