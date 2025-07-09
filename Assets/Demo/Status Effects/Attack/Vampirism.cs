using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Attack/Vampirism")]
public class Vampirism : StatusEffectData
{
    public override void BeforePlayerAttack(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {
            for(int i = 0; i < combatManager.enemy.damages.Count; i++)
            {
                int heal = (int)(combatManager.enemy.damages[i] * stack / 100f);
                combatManager.player.stats.health += heal;
                Debug.Log($"흡혈로 인해 플레이어의 체력 {heal} 회복");
            }
            combatManager.player.stats.health = Mathf.Min(combatManager.player.stats.health, combatManager.player.stats.maxHealth);
        }
    }
    public override void BeforeEnemyAttack(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer)
        {
            for (int i = 0; i < combatManager.player.damages.Count; i++)
            {
                int heal = (int)(combatManager.player.damages[i] * stack / 100f);
                combatManager.enemy.stats.health += heal;
                Debug.Log($"흡혈로 인해 상대의 체력 {heal} 회복");
            }
            combatManager.enemy.stats.health = Mathf.Min(combatManager.enemy.stats.health, combatManager.enemy.stats.maxHealth);
        }
    }
}