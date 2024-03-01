using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SettingsData
{
    public float volume;
    public FullScreenMode mode;
    public Resolution resolution;

    public SettingsData()
    {
        volume = 0f;
        mode = FullScreenMode.ExclusiveFullScreen;
        resolution.width = 1920;
        resolution.height = 1080;
    }
}
