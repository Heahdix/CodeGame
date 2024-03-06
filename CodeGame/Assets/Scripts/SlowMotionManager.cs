using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SlowMotionManager : MonoBehaviour
{
    public float slowMotionTime = 10f;
    public TMP_InputField inputField;
    public Bar slowMoTime;

    private float _residualTime;
    private bool _timeSlowed = false;
    private bool _fullTimeUsed = false;
    private GameManager _gameManager;

    void Start()
    {
        _gameManager = GameManager.instance;
        _residualTime = slowMotionTime;
        slowMoTime.SetMaxValue(slowMotionTime);
    }

    void Update()
    {
        if (!_timeSlowed)
        {
            if (inputField.text != "" && !_fullTimeUsed && _gameManager.isInBattle)
            {
                StartCoroutine(SlowMotion());
            }
            else
            {
                if (_residualTime < slowMotionTime)
                {
                    _residualTime += Time.deltaTime * 0.5f;
                    slowMoTime.SetValue(_residualTime);
                }
                else
                {
                    _fullTimeUsed = false;
                }
            }
        }       
    }

    IEnumerator SlowMotion()
    {
        Time.timeScale = 0.2f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        _timeSlowed = true;
        while (inputField.text != "" && _residualTime >= 0 && _gameManager.isInBattle)
        {
            _residualTime -= Time.deltaTime * 1/0.2f;
            slowMoTime.SetValue(_residualTime);
            yield return null;
        }

        if (_residualTime <= 0)
        {
            _fullTimeUsed = true;
        }
        _timeSlowed = false;
        SetNormalTime();
    }

    private void SetNormalTime()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}
