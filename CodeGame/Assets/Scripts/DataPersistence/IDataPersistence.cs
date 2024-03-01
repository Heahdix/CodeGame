using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistence
{
    void LoadData(SettingsData settingsData);

    void SaveData(ref SettingsData data);
}
