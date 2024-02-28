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
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            string[] text = InputField.text.Split('.', '(', ')', ';', ',');
            InputField.text = "";
            InputField.Select();
            InputField.ActivateInputField();

            if (text[0].Equals("Player"))
            {
                Type type = _player.GetType();

                MethodInfo methodInfo = type.GetMethod(text[1], BindingFlags.NonPublic | BindingFlags.Instance);
                if (methodInfo == null)
                {
                    Debug.Log("������ ������ � ������ ���");
                }
                else if (text.Length >= 3)
                {
                    string parameter = text[2];
                    try
                    {
                        methodInfo.Invoke(_player, new[] { parameter });
                    }
                    catch
                    {
                        Debug.Log("�������� ���������");
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
                        Debug.Log("�������� ���������");
                    }
                }
            }
            else
            {
                var comp = weaponManager.GetComponent(text[0]);

                if (comp == null)
                {
                    Debug.Log("������ �������� ��� � ���������");
                }
                else
                {
                    Type type = comp.GetType();

                    MethodInfo methodInfo = type.GetMethod(text[1], BindingFlags.NonPublic | BindingFlags.Instance);
                    if (methodInfo == null)
                    {
                        Debug.Log("������ ������ � ������ ���");
                    }
                    else
                    {
                        methodInfo.Invoke(comp, null);
                    }
                }
            }
        }

    }

}
