using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItems : MonoBehaviour
{
    public List<MonoBehaviour> weapons = new List<MonoBehaviour>();


    private void Awake()
    {
        //weapons.Add(gameObject.AddComponent<Fireball>());
    }

}
