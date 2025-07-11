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
            if (instance == null) instance = new GameManager();
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
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/TextRPG.sav";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData();
        data.stageIndex = stageIndex;
        data.actIndex = actIndex;
        data.coin = coin;
        data.playerData = playerData;
        data.resultData = resultData;

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public void Load()
    {
        string path = Application.persistentDataPath + "/TextRPG.sav";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

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