using UnityEngine;

[CreateAssetMenu(menuName = "Data/StatusEffect/Attack/Vampirism")]
public class Vampirism : StatusEffectData
{
    public int totalHeal;
    public override void BeforePlayerAttack(CombatManager combatManager)
    {
        if(stack > 0 && isPlayer)
        {
            for(int i = 0; i < combatManager.enemy.damages.Count; i++)
            {
                int heal = (int)(combatManager.enemy.damages[i] * stack / 100f);
                totalHeal += heal;
            }
        }
    }
    public override void BeforeEnemyAttack(CombatManager combatManager)
    {
        if (stack > 0 && !isPlayer)
        {
            for (int i = 0; i < combatManager.player.damages.Count; i++)
            {
                int heal = (int)(combatManager.player.damages[i] * stack / 100f);
                totalHeal += heal;
            }
        }
    }
    public override void AfterPlayerAttack(CombatManager combatManager)
    {
        if(totalHeal > 0 && isPlayer)
        {
            combatManager.player.stats.health
                = Mathf.Min(combatManager.player.stats.health + totalHeal, combatManager.player.stats.maxHealth);
            Debug.Log($"흡혈로 체력이 {totalHeal} 회복되었다!");
            totalHeal = 0;
        }
    }
    public override void AfterEnemyAttack(CombatManager combatManager)
    {
        if (totalHeal > 0 && !isPlayer)
        {
            combatManager.enemy.stats.health
                = Mathf.Min(combatManager.enemy.stats.health + totalHeal, combatManager.enemy.stats.maxHealth);
            Debug.Log($"흡혈로 적의 체력이 {totalHeal} 회복되었다!");
            totalHeal = 0;
        }
    }
}