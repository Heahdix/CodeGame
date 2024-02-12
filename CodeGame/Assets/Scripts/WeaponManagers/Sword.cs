using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : CommandExecutor
{
    public void Swing()
    {
        GameObject sword = Instantiate(weaponPrefab, transform.position, weaponPrefab.transform.rotation);
        
    }
}
