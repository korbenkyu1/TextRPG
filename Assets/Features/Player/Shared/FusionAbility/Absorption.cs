using UnityEngine;
[CreateAssetMenu(menuName = "Data/FusionAbility/Absorption")]
public class Absorption : AbilityData
{
    public int heal;
    public override void BeforePlayerAttack(CombatManager combatManager)
    {
        for(int i = 0; i < combatManager.enemy.damages.Count; i++)
        {
            int healValue = (int) (combatManager.enemy.damages[i]*0.25f);
            heal += Mathf.Max(1, healValue);            
        }
    }
    public override void AfterPlayerAttack(CombatManager combatManager)
    {
        combatManager.player.stats.health
            = Mathf.Min(combatManager.player.stats.maxHealth, combatManager.player.stats.health + heal);
        combatManager.Log($"흡수로 체력이 {heal} 회복되었다!");
        heal = 0;
    }
}