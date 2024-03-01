using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour, IDataPersistence
{
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;

    Resolution currentResolution;
    FullScreenMode fullScreenMode;

    Resolution[] resolutions;

    public void LoadData(SettingsData data)
    {
        audioMixer.SetFloat("Volume", data.volume);
        currentResolution.width = data.resolutionWidth;
        currentResolution.height = data.resolutionHeight;
        fullScreenMode = data.mode;
    }

    public void SaveData(ref SettingsData data)
    {
        audioMixer.GetFloat("Volume", out data.volume);
        data.resolutionHeight = currentResolution.height;
        data.resolutionWidth = currentResolution.width;
        data.mode = fullScreenMode;
    }

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == currentResolution.width && resolutions[i].height == currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        currentResolution = resolution;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat(name: "Volume", volume);
    }

    public void SetResizeMode(int resizeIndex)
    {
        switch (resizeIndex)
        {
            case 0:
                fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                Screen.fullScreenMode = fullScreenMode;
                break;
            case 1:
                fullScreenMode = FullScreenMode.MaximizedWindow;
                Screen.fullScreenMode = fullScreenMode;
                break;
            case 2:
                fullScreenMode = FullScreenMode.Windowed;
                Screen.fullScreenMode = fullScreenMode;
                break;
        }
    }

    public void OnSaveButtonClicked()
    {
        DataPersistenceManager.instance.SaveGame();
    }
}
