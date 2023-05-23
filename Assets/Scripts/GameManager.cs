using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;
    string pathForSave;
    public GameData gameData;

    [System.Serializable]
    public class GameData
    {
        public string playerName;
        public string bestPlayer;
        public int bestScore;
    }

    private void Awake()
    {
        pathForSave = Application.persistentDataPath + "/savedata.json";
        if (Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
    public void SaveData()
    {
        string jsonSave = JsonUtility.ToJson(gameData);
        File.WriteAllText(pathForSave, jsonSave);
    }
    public void LoadData()
    {
        if (File.Exists(pathForSave))
        {
            string jsonSave = File.ReadAllText(pathForSave);
            gameData = JsonUtility.FromJson<GameData>(jsonSave);
        }
    }
}
