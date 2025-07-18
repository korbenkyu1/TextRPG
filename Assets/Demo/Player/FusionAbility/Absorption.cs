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
        Debug.Log($"흡수 융합특성으로 인해 플레이어의 체력 {heal} 회복");
        heal = 0;
    }
}