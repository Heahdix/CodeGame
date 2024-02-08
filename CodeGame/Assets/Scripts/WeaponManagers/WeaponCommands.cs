using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;

public class WeaponCommands : MonoBehaviour
{
    public TMP_InputField InputField;
    public GameObject weaponManager;

    void Start()
    {
        //weaponManager = player.GetComponentInChildren<WeaponManager>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            string[] text = InputField.text.Split('.', '(', ')', ';');
            //Debug.Log(weaponManager.name);

            var comp = weaponManager.GetComponent(text[0]);

            if (comp == null)
            {
                Debug.Log("Такого предмета нет в инвентаре");
            }

            else
            {
                Type type = comp.GetType();

                MethodInfo methodInfo = type.GetMethod(text[1], BindingFlags.NonPublic | BindingFlags.Instance);
                if (methodInfo == null)
                {
                    Debug.Log("Такогно метода у оружия нет");
                }
                else
                {
                    methodInfo.Invoke(comp, null);
                }
            }
        }

    }

}
