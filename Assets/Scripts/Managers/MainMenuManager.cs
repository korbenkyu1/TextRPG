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

    [SerializeField] PlayerData[] playerData;
    PlayerData selectedPlayer;
    void Start()
    {
        foreach(var player in playerData)
        {
            if (player == null)
            {
                var button = Instantiate(PlayerButtonPrefab, PlayerButtonContainer);
                button.interactable = false;
                continue;
            }
            else
            {
                var button = Instantiate(PlayerButtonPrefab, PlayerButtonContainer);
                button.GetComponentInChildren<TMP_Text>().text = player.unitName;
                button.onClick.AddListener(() =>
                {
                    PlayerImage.sprite = player.image;
                    PlayerName.text = player.unitName;
                    PlayerDescription.text = player.description;
                    PlayerFlavorText.text = $"'{player.flavorText}'";
                    selectedPlayer = player;
                });
            }
        }
        selectedPlayer = playerData[0];
    }
    public void GameStart()
    {
        if (selectedPlayer == null) return;

        GameManager.Instance.playerData = selectedPlayer;
        SceneManager.LoadScene("ActScene");
    }
}
