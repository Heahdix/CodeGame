using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : CommandExecutor
{
    public void Launch()
    {
        GameObject fireball = Instantiate(weaponPrefab, transform.position, weaponPrefab.transform.rotation);
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        rb.AddForce((GameObject.FindGameObjectsWithTag("Enemy")[0].transform.position - gameObject.transform.position) * weaponData.speed, ForceMode2D.Impulse);
    }
}
