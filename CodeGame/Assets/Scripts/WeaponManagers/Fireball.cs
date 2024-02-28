using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : CommandExecutor
{
    private void Launch()
    {
        if (manaSystem.CanAffordSkill(weaponData.RamUsage))
        {
            var distance = Mathf.Infinity;
            GameObject closestEnemy = null;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                float diff = Vector2.Distance(transform.position, enemy.transform.position);
                if (diff < distance)
                {
                    closestEnemy = enemy;
                }
            }
            if (closestEnemy != null)
            {
                GameObject fireball = Instantiate(weaponPrefab, transform.position, weaponPrefab.transform.rotation);
                Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();

                rb.AddForce((closestEnemy.transform.position - gameObject.transform.position) * weaponData.speed, ForceMode2D.Impulse);

                manaSystem.DecreaseMana(weaponData.RamUsage);
            }
        }
    }
}
