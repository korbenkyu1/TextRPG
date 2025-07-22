using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class GameData
{
    public int stageIndex;
    public int actIndex;
    public int coin;
    public PlayerData playerData;
    public ResultData resultData;
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

    public int stageIndex;
    public int actIndex;
    public int coin;
    public PlayerData playerData;
    public EnemyData enemyData;
    public ResultData resultData;

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
        BinaryFormatter formatter = new ();
        string path = Application.persistentDataPath + "/TextRPG.sav";
        FileStream stream = new (path, FileMode.Create);

        GameData data = new()
        {
            stageIndex = stageIndex,
            actIndex = actIndex,
            coin = coin,
            playerData = playerData,
            resultData = resultData
        };

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public void Load()
    {
        string path = Application.persistentDataPath + "/TextRPG.sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new ();
            FileStream stream = new (path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stageIndex = data.stageIndex;
            actIndex = data.actIndex;
            coin = data.coin;
            playerData = data.playerData;
            resultData = data.resultData;
            SceneManager.LoadScene("ActScene");
        }
        else
        {
            Debug.Log("Save file not found.");
        }

    }
}