using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] PlayerData player;

    void Start()
    {
        // Init GameManager
        GameManager.Instance.stageIndex = 0;
        GameManager.Instance.actIndex = 0;
        GameManager.Instance.playerData = player;

    }

    void Update()
    {
        if(Input.anyKey)
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    }
}