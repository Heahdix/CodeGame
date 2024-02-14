using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaSystem : MonoBehaviour
{
    public Bar manaBar;

    private float currentMana;
    private float maxMana;

    private void Start()
    {
        manaBar = GetComponent<Bar>();
    }

    private void Update()
    {
        if (currentMana < maxMana)
        {
            if (currentMana < maxMana)
            {
                currentMana = Mathf.MoveTowards(currentMana, maxMana, Time.deltaTime * 5f);
                manaBar.SetValue(currentMana);
            }
        }
    }

    public void SetMaxMana(float value)
    {
        maxMana = value;
        manaBar.SetMaxValue(maxMana);
    }
    public bool CanAffordSkill(float value)
    {
        Debug.Log(currentMana);
        Debug.Log(value);
        return currentMana > value;
    }

    public void DecreaseMana(float value)
    {
        currentMana -= value;
        manaBar.SetValue(currentMana);
    }
}
