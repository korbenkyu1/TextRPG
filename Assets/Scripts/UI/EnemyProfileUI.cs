using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyProfileUI : MonoBehaviour
{
    public Image EnemyImage;
    public TMP_Text EnemyName;
    public TMP_Text EnemyDescription;
    public TMP_Text EnemyFlavorText;

    public TMP_Text Attack;
    public TMP_Text Defense;
    public TMP_Text Dodge;
    public TMP_Text Critical;
    void OnEnable()
    {
        EnemyData enemy = GameManager.Instance.enemyData;

        EnemyImage.sprite = enemy.image;
        EnemyName.text = enemy.unitName;
        EnemyDescription.text = enemy.description;

        Attack.text = enemy.attack.ToString();
        Defense.text = enemy.defense.ToString();
        Dodge.text = enemy.dodgeChance.ToString() + "%";
        Critical.text = enemy.critChance.ToString() + "%";

        EnemyFlavorText.text = enemy.flavorText;

        // Ability
    }
}
