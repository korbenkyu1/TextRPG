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
        foreach (Transform child in PlayerButtonContainer) Destroy(child.gameObject);
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
                    PlayerFlavorText.text = playerData.flavorText;
                    selectedPlayer = playerData;
                });
            }
        }
        selectedPlayer = playerDatas[0];
    }
    public void GameStart()
    {
        GameManager.Instance.playerData = selectedPlayer;
        Debug.Log(selectedPlayer);
        Debug.Log(GameManager.Instance.playerData);
        SceneManager.LoadScene("StageScene");
    }
}
