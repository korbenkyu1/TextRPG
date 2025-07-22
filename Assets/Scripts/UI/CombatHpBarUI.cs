using UnityEngine;
using UnityEngine.UI;

public class CombatHpBar : MonoBehaviour
{
    [SerializeField] Slider hpBar;
    [SerializeField] bool isPlayer;
    public void UpdateUI(CombatManager combatManager)
    {
        StatsData stats = isPlayer ? combatManager.player.stats : combatManager.enemy.stats;

        hpBar.maxValue = stats.maxHealth;
        hpBar.value = stats.health;
    }
}
