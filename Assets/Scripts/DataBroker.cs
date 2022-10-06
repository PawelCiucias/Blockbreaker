using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataBroker : MonoBehaviour
{


    public static DataBroker Instance;

    private string playerName;
    public string PlayerName
    {
        get { return playerName; }
        set
        {
            playerName = value;
        }
    }

    private int highScore;
    public int HighScore
    {
        get { return highScore; }
        set
        {
            if (highScore < value)
                highScore = value;
        }
    }


    private void Awake()
    {
        if (DataBroker.Instance == null)
        {
            Instance = this;

            //DontDestorOnLoad marks the MainManager GameObject attached to this script 
            //not to be destroyed when the scene changes.
            DontDestroyOnLoad(gameObject);
            LoadPlayerDetails();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    public void SavePlayerDetails()
    {
        SaveData data = new SaveData();
        data.PlayerName = playerName;
        data.HighScore = HighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile1.json", json);
    }

    public SaveData LoadPlayerDetails()
    {
        string path = Application.persistentDataPath + "/savefile1.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<SaveData>(json);
        }

        return null;
    }
    [System.Serializable]
    public class SaveData
    {
        public string PlayerName;
        public int HighScore;
    }
}
