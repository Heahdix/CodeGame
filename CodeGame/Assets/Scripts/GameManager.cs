using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float slowMotionTime = 2f;
    public TMP_InputField InputField;

    private float residualTime;
    private bool timeSlowed = false;
    private bool fullTimeUsed = false;

    void Start()
    {
        residualTime = slowMotionTime;
    }

    void Update()
    {
        if (!timeSlowed)
        {
            if (InputField.text != "" && !fullTimeUsed)
            {
                StartCoroutine(SlowMotion());
            }
            else
            {
                if (residualTime < slowMotionTime)
                {
                    residualTime += Time.deltaTime * 0.25f;
                }                
                else
                {
                    fullTimeUsed = false;
                }

            }
        }
        
    }

    IEnumerator SlowMotion()
    {
        Time.timeScale = 0.3f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        float startTime = Time.time;
        timeSlowed = true;
        while (InputField.text != "" && residualTime >= 0)
        {
            residualTime -= Time.deltaTime * 1/0.3f;
            yield return null;
        }

        if (residualTime <= 0)
        {
            fullTimeUsed = true;
        }
        timeSlowed = false;
        SetNormalTime();
    }

    private void SetNormalTime()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}
