using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Image PlayerImage;
    public TMP_Text PlayerName;
    public TMP_Text PlayerDescription;
    public TMP_Text PlayerFlavorText;
    public Transform PlayerButtonContainer;
    public Button PlayerButtonPrefab;

    [SerializeField] PlayerData[] playerDatas;
    PlayerData selectedPlayer;
    void Start()
    {
        foreach(var playerData in playerDatas)
        {
            if (playerData == null)
            {
                var button = Instantiate(PlayerButtonPrefab, PlayerButtonContainer);
                button.interactable = false;
                continue;
            }
            else
            {
                var button = Instantiate(PlayerButtonPrefab, PlayerButtonContainer);
                button.GetComponentInChildren<TMP_Text>().text = playerData.unitName;
                button.onClick.AddListener(() =>
                {
                    PlayerImage.sprite = playerData.image;
                    PlayerName.text = playerData.unitName;
                    PlayerDescription.text = playerData.description;
                    PlayerFlavorText.text = $"'{playerData.flavorText}'";
                    selectedPlayer = playerData;
                });
            }
        }
        selectedPlayer = playerDatas[0];
    }
    public void GameStart()
    {
        if (selectedPlayer == null) return;

        GameManager.Instance.playerData = selectedPlayer;
        SceneManager.LoadScene("StageScene");
    }
}
