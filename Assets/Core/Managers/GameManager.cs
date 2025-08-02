using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using System;

public enum Speed
{
    Slow,
    Normal,
    Fast,
}

[Serializable]
public class Settings
{
    public bool music = true;
    public bool sfx = true;
    public Speed speed = Speed.Fast;
}
public class GameData
{
    public int actIndex;
    public int stageIndex;
    public int coin;
    public PlayerData playerData;
    public ResultData resultData;
    public Settings settings;
}

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null) instance = new ();
            return instance;
        }
    }

    public ActData[] actDatas;
    public int actIndex = 0;
    public int stageIndex = 0;
    public int coin = 0;
    public PlayerData playerData;
    public EnemyData enemyData;
    public ResultData resultData;
    public Settings settings;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    public void Save()
    {
        GameData data = new()
        {
            actIndex = actIndex,
            stageIndex = stageIndex,
            coin = coin,
            playerData = playerData,
            resultData = resultData,
            settings = settings,
        };
        string json = JsonUtility.ToJson(data);

        PlayerPrefs.SetString("Save", json);
        PlayerPrefs.Save();
    }
    public void Load()
    {
        if (PlayerPrefs.HasKey("Save"))
        {
            string json = PlayerPrefs.GetString("Save");
            GameData data = JsonUtility.FromJson<GameData>(json);

            actIndex = data.actIndex;
            stageIndex = data.stageIndex;
            coin = data.coin;
            playerData = data.playerData;
            resultData = data.resultData;
            settings = data.settings;
            SceneManager.LoadScene("ActScene");
        }
        else
        {
            Debug.Log("Save not found.");
        }
    }
    public void LoadNext()
    {
        stageIndex++;
        if (stageIndex == actDatas[actIndex].fixedStages.Length) {
            stageIndex = 0;
            actIndex++;
        }
        if(actIndex == actDatas.Length)
        {
            Debug.Log("Game Clear");
            SceneManager.LoadScene("ResultScene");
            return;
        }

        SceneManager.LoadScene("StageScene");
    }
}