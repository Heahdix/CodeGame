using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TMPro;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class WeaponCommands : MonoBehaviour
{
    public TMP_InputField InputField;
    public GameObject weaponManager;

    private Player _player;

    private void Awake()
    {
        InputField.Select();
        InputField.ActivateInputField();
    }

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        //weaponManager = player.GetComponentInChildren<WeaponManager>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            string[] text = InputField.text.Split('.', '(', ')', ';', ',');
            //Debug.Log(weaponManager.name);
            InputField.text = "";
            InputField.Select();
            InputField.ActivateInputField();

            if (text[0].Equals("Player"))
            {
                Type type = _player.GetType();

                MethodInfo methodInfo = type.GetMethod(text[1], BindingFlags.NonPublic | BindingFlags.Instance);
                if (methodInfo == null)
                {
                    Debug.Log("Такого метода у игрока нет");
                }
                else if (text.Length >= 3)
                {
                    var subArray = text.Skip(2).ToArray();
                    string parameter = text[2];
                    try
                    {
                        methodInfo.Invoke(_player, new[] { parameter });
                    }
                    catch
                    {
                        Debug.Log("Неверные параметры");
                    }
                }
                else
                {
                    try
                    {
                        methodInfo.Invoke(_player, null);
                    }
                    catch
                    {
                        Debug.Log("Неверные параметры");
                    }
                }
            }
            else
            {
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
                        Debug.Log("Такого метода у оружия нет");
                    }
                    //else if (text.Length >= 3)
                    //{
                    //    var subArray = text.Skip(2).ToArray();
                    //    try
                    //    {
                    //        methodInfo.Invoke(comp, new[] { subArray });
                    //    }
                    //    catch
                    //    {
                    //        Debug.Log("Неверные параметры");
                    //    }
                    //}
                    else
                    {
                        try
                        {
                            methodInfo.Invoke(comp, null);
                        }
                        catch
                        {
                            Debug.Log("Неверные параметры");
                        }
                    }
                }
            }
        }

    }

}
