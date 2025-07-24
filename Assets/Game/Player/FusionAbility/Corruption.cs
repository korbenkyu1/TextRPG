using UnityEngine;

[CreateAssetMenu(menuName = "Data/FusionAbility/Corruption")]
public class Corruption : AbilityData
{
    public override void OnTurnEnd(CombatManager combatManager)
    {
        combatManager.enemy.stats.health -= 50;
        Debug.Log("부패 융합특성으로 50의 특수피해 부여");
    }
}