using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProfileUI : MonoBehaviour
{
    public Image PlayerImage;
    public TMP_Text PlayerName;
    public TMP_Text PlayerDescription;

    public TMP_Text Attack;
    public TMP_Text Dodge;
    public TMP_Text Defense;
    public TMP_Text Critical;
    void OnEnable()
    {
        PlayerData player = GameManager.Instance.playerData;

        PlayerImage.sprite = player.image;
        PlayerName.text = player.unitName;
        PlayerDescription.text = player.description;

        Attack.text = player.attack.ToString();
        Dodge.text = player.dodgeChance.ToString()+"%";
        Defense.text = player.defense.ToString();
        Critical.text = player.critChance.ToString()+"%";


    }
}
