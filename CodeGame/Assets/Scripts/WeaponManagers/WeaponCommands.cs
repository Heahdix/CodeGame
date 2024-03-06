using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class WeaponCommands : MonoBehaviour
{
    public TMP_InputField InputField;
    public GameObject weaponManager;

    private Player _player;
    private string _regex = @"(\.[\s\n\r]*[\w]+)[\s\n\r]*(?=\(.*\))";
    private GameManager _gameManager;

    private void Awake()
    {
        InputField.Select();
        InputField.ActivateInputField();
    }

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        InputField.Select();
        InputField.ActivateInputField();
        _gameManager = GameManager.instance;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (InputField.text.Length > 0)
            {

                string[] text = InputField.text.Split('.', '(', ')', ';', ',');

                if (text[0].Equals("pd"))
                {
                    Type type = _player.GetType();

                    MethodInfo methodInfo = type.GetMethod("Dash", BindingFlags.NonPublic | BindingFlags.Instance);
                    if (methodInfo == null)
                    {
                        Debug.Log("Такого метода у игрока нет");
                    }
                    else if (text.Length >= 3)
                    {
                        string parameter = text[1];
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
                            Debug.Log(message: "Неверные параметры");
                        }
                    }
                }
                else
                {
                    if (Regex.IsMatch(InputField.text, _regex, RegexOptions.None))
                    {
                        var comp = weaponManager.GetComponent(text[0]);

                        if (comp == null)
                        {
                            Debug.Log("Такого предмета нет в инвентаре");
                        }
                        else if (_gameManager.isInBattle)
                        {
                            Type type = comp.GetType();

                            MethodInfo methodInfo = type.GetMethod(text[1], BindingFlags.NonPublic | BindingFlags.Instance);
                            if (methodInfo == null)
                            {
                                Debug.Log("Такого метода у оружия нет");
                            }
                            else
                            {
                                methodInfo.Invoke(comp, null);
                            }
                        }
                        else
                        {
                            Debug.Log(message: "Сейчас не идёт бой");
                        }
                    }
                    else
                    {
                        Debug.Log("Написанное не соответствует синтаксису метода");
                    }
                }
            }
            else
            {
                Debug.Log("Пусто");
            }

            InputField.text = "";
            InputField.Select();
            InputField.ActivateInputField();
        }
    }
}


