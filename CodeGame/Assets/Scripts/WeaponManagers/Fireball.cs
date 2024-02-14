using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : CommandExecutor
{
    private void Launch()
    {
        if (manaSystem.CanAffordSkill(weaponData.RamUsage))
        {
            GameObject fireball = Instantiate(weaponPrefab, transform.position, weaponPrefab.transform.rotation);
            Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();

            rb.AddForce((GameObject.FindGameObjectsWithTag("Enemy")[0].transform.position - gameObject.transform.position) * weaponData.speed, ForceMode2D.Impulse);

            manaSystem.DecreaseMana(weaponData.RamUsage);
        }
    }
}
