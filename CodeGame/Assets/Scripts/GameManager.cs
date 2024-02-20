using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float slowMotionTime = 1f;
    public TMP_InputField InputField;

    private float residualTime;
    private bool timeSlowed = false;

    // Start is called before the first frame update
    void Start()
    {
        residualTime = slowMotionTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (InputField.text != "" && residualTime >= slowMotionTime)
        {
            StartCoroutine(SlowMotion()); 
        }
        else if (!timeSlowed)
        {
            if (residualTime < slowMotionTime)
            {
                residualTime += Time.deltaTime * 0.25f;
                Debug.Log(residualTime);
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
        timeSlowed = false;
        SetNormalTime();
    }

    private void SetNormalTime()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}
