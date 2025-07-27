using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HpBarUI : MonoBehaviour
{
    [SerializeField] Slider hpBar;
    [SerializeField] TMP_Text hpText;
    public void UpdateHp(int maxHealth, int health)
    {
        hpBar.maxValue = maxHealth;
        hpBar.value = health;
        hpText.text = $"{health}/{maxHealth}";
    }
}
