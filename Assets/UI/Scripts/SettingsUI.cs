using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] Button music, sfx, speed, title;
    Settings settings;

    void OnEnable()
    {
        UpdateUI();
    }
    public void UpdateUI()
    {
        settings = GameManager.Instance.settings;

        music.GetComponentInChildren<TMP_Text>().text = $"배경음 : {(settings.music ? "ON" : "OFF")}";
        sfx.GetComponentInChildren<TMP_Text>().text = $"효과음 : {(settings.sfx ? "ON" : "OFF")}";
    }
    public void OnMusicButton()
    {
        settings.music = !settings.music;
        GameManager.Instance.settings = settings;
        UpdateUI();
    }
    public void ONSFXButton()
    {
        settings.sfx = !settings.sfx;
        GameManager.Instance.settings = settings;
        UpdateUI();
    }
    public void OnSpeedButton()
    {

    }
    public void OnTitleButton()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
