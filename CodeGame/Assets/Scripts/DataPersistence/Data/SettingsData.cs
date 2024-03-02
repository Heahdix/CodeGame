using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SettingsData
{
    public float volume;
    public FullScreenMode mode;
    public int resolutionWidth;
    public int resolutionHeight;

    public SettingsData()
    {
        volume = 0f;
        mode = FullScreenMode.ExclusiveFullScreen;
        resolutionWidth = 1920;
        resolutionHeight = 1080;
    }
}
