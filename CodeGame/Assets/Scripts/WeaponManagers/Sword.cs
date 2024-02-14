using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Sword : CommandExecutor
{
    private GameObject sword;
    private void Awake()
    {
        sword = Instantiate(weaponPrefab, transform.position, weaponPrefab.transform.rotation);

        sword.SetActive(false);
        sword.transform.parent = transform;
    }
    private void Swing()
    {
        if (manaSystem.CanAffordSkill(weaponData.RamUsage))
        {
            Vector3 Look = sword.transform.InverseTransformPoint(GameObject.FindGameObjectsWithTag("Enemy")[0].transform.position);
            float Angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg - 90;

            sword.transform.Rotate(0, 0, Angle);

            sword.SetActive(true);
            manaSystem.DecreaseMana(weaponData.RamUsage);
        }
    }
}
