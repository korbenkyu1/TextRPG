using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    public void LoadGame()
    {
        GameManager.Instance.Load();
    }
}