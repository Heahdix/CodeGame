using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Sword : CommandExecutor
{
    private GameObject _sword;
    private void Awake()
    {
        _sword = Instantiate(weaponPrefab, transform.position, weaponPrefab.transform.rotation);

        _sword.SetActive(false);
        _sword.transform.parent = transform;
    }
    private void Swing()
    {
        if (manaSystem.CanAffordSkill(weaponData.RamUsage))
        {
            Vector3 Look = _sword.transform.InverseTransformPoint(GameObject.FindGameObjectsWithTag("Enemy")[0].transform.position);
            float Angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg - 90;

            _sword.transform.Rotate(0, 0, Angle);

            _sword.SetActive(true);
            manaSystem.DecreaseMana(weaponData.RamUsage);
        }
    }
}
