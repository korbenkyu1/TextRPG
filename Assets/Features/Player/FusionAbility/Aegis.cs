using UnityEngine;
[CreateAssetMenu(menuName = "Data/FusionAbility/Aegis")]
public class Aegis : AbilityData
{
    public bool isAssigned = false;
    public override void OnTurnStart(CombatManager combatManager)
    {
        if (!isAssigned)
        {
            combatManager.player.statusEffects["reduction"].stack += 45;
            combatManager.Log("ö������ �氨 45 ������ �����!");
            isAssigned = true;
        }
    }
}