using UnityEngine;

[CreateAssetMenu(menuName = "Data/FusionAbility/Cycle")]
public class Cycle : AbilityData
{
    public override void OnTurnEnd(CombatManager combatManager)
    {
        combatManager.enemy.stats.health -= 15;
        combatManager.player.stats.health
            = Mathf.Min(combatManager.player.stats.maxHealth, combatManager.player.stats.health + 15);
        Debug.Log("순환 융합특성으로 인해 상대는 15의 데미지를 받고, 플레이어는 15의 체력을 회복했다");
    }
}