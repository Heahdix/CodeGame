using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string _filename;

    private SettingsData _settingsData;
    private List<IDataPersistence> _dataPersistenceObjects;
    private FileDataHandler _fileDataHandler;

    public static DataPersistenceManager instance { get; private set; }

    private void Awake()
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

    private void Start()
    {
        this._fileDataHandler = new FileDataHandler(Application.persistentDataPath, _filename);
        this._dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this._settingsData = new SettingsData();
    }

    public void LoadGame()
    {
        this._settingsData = _fileDataHandler.Load();

        if (this._settingsData == null)
        {
            Debug.Log("≈ще нет данных");
            NewGame();
        }

        foreach (IDataPersistence dataPersistenceObj in this._dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(_settingsData);
        }
    }

    public void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObj in this._dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref _settingsData);
        }

        _fileDataHandler.Save(_settingsData);
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> _dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();
        return new List<IDataPersistence> (_dataPersistenceObjects);
    }
}
