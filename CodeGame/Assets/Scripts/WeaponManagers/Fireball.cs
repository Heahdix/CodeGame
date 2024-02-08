using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : CommandExecutor
{
    public override void Attack()
    {
        GameObject fireball = Instantiate(weaponPrefab, transform.position, weaponPrefab.transform.rotation);
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        rb.AddForce((GameObject.Find("Enemy").transform.position - gameObject.transform.position) * weaponData.speed, ForceMode2D.Impulse);
    }
}
