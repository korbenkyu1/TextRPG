using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HpBarUI : MonoBehaviour
{
    [SerializeField] Slider hpBar;
    [SerializeField] TMP_Text hpText;
    [SerializeField] bool isPlayer;
    public void UpdateUI()
    {
        hpBar.maxValue = GameManager.Instance.playerData.maxHealth;
        hpBar.value = GameManager.Instance.playerData.health;
        hpText.text = $"{hpBar.value}/{hpBar.maxValue}";
    }
    public void UpdateUI(CombatManager combatManager)
    {
        StatsData stats = isPlayer ? combatManager.player.stats : combatManager.enemy.stats;

        hpBar.maxValue = stats.maxHealth;
        hpBar.value = stats.health;
        hpText.text = $"{hpBar.value}/{hpBar.maxValue}";
    }
}
