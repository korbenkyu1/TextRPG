using UnityEngine;

[CreateAssetMenu(menuName = "Data/FusionAbility/Madness")]
public class Madness : AbilityData
{
    int count;
    public override void BeforeEnemyAttack(CombatManager combatManager)
    {
        count += combatManager.player.damages.Count;
    }
    public override void AfterEnemyAttack(CombatManager combatManager)
    {
        combatManager.enemy.stats.health -= count * 40;
        Debug.Log($"플레이어의 광기 융합특성으로 인해 상대는 {count * 40}의 데미지를 입었다");
        count = 0;
    }
}