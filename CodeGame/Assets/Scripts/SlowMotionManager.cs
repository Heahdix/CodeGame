using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SlowMotionManager : MonoBehaviour
{
    public float slowMotionTime = 2f;
    public TMP_InputField inputField;
    public bool isInBattle = false;

    private float _residualTime;
    private bool _timeSlowed = false;
    private bool _fullTimeUsed = false;

    public static SlowMotionManager instance { get; private set; }

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        _residualTime = slowMotionTime;
    }

    void Update()
    {
        if (!_timeSlowed)
        {
            if (inputField.text != "" && !_fullTimeUsed)
            {
                StartCoroutine(SlowMotion());
            }
            else
            {
                if (_residualTime < slowMotionTime)
                {
                    _residualTime += Time.deltaTime * 0.25f;
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
        Time.timeScale = 0.3f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        _timeSlowed = true;
        while (inputField.text != "" && _residualTime >= 0)
        {
            _residualTime -= Time.deltaTime * 1/0.3f;
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
