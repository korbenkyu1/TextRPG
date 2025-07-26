using UnityEngine;
[CreateAssetMenu(menuName = "Data/FusionAbility/Corruption")]
public class Corruption : AbilityData
{
    public override void OnTurnEnd(CombatManager combatManager)
    {
        combatManager.enemy.stats.health -= 50;
        combatManager.Log("부패로 적의 체력이 50 감소되었다!");
    }
}